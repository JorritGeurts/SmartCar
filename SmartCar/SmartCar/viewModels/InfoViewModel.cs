﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SafariSnap.Services;
using SmartCar.Models;
using SmartCar.Services;
using SmartCar.viewModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;


namespace SmartCar.ViewModels
{
    public class InfoViewModel : ObservableObject, IInfoViewModel
    {
        private bool isRunning = false;
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }

        private ObservableCollection<ImageSource> photos = new ObservableCollection<ImageSource>();
        public ObservableCollection<ImageSource> Photos
        {
            get => photos;
            set
            {
                SetProperty(ref photos, value);
                OnPropertyChanged(nameof(HasPhotos));
                OnPropertyChanged(nameof(CanPickOrTakePhoto));
            }
        }

        public bool HasPhotos => Photos?.Count >= 1;
        public bool CanPickOrTakePhoto => !HasPhotos;
        private SmarterCar classifiedCar;
        public SmarterCar ClassifiedCar
        {
            get => classifiedCar;
            set => SetProperty(ref classifiedCar, value);
        }

        public ICommand PickPhotoCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }
        public ICommand AddPhotoCommand { get; set; }
        public ICommand RemovePhotoCommand { get; set; }
        public ICommand ShowAddPhotoMenuCommand { get; set; }

        public InfoViewModel()
        {
            BindCommands();
        }

        private void BindCommands()
        {
            PickPhotoCommand = new AsyncRelayCommand(PickAndClassifyPhoto);
            TakePhotoCommand = new AsyncRelayCommand(TakeAndClassifyPhoto);
            ShowAddPhotoMenuCommand = new RelayCommand(ShowAddPhotoMenu);
            AddPhotoCommand = new AsyncRelayCommand(AddPhotoCommandExecute);
            RemovePhotoCommand = new RelayCommand<ImageSource>(RemovePhotoCommandExecute);
        }
        private async Task PickPhoto()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            await AddPhoto(photo);
        }

        private async Task TakePhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await AddPhoto(photo);
        }

        private void ShowAddPhotoMenu()
        {
            Application.Current.MainPage.DisplayActionSheet("Add Photo", "Cancel", null, "Pick Photo", "Take Photo")
                .ContinueWith(async (task) =>
                {
                    var action = await task;
                    if (action == "Pick Photo")
                    {
                        await PickPhoto();
                    }
                    else if (action == "Take Photo")
                    {
                        await TakePhoto();
                    }
                });
        }
        private async Task AddPhoto(FileResult photo)
        {
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                Photos.Add(ImageSource.FromStream(() => stream));
                OnPropertyChanged(nameof(HasPhotos));
            }
        }


        private async Task PickAndClassifyPhoto()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            await ClassifyPhotoAsync(photo);
        }

        private async Task TakeAndClassifyPhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await ClassifyPhotoAsync(photo);
        }

        private async Task AddPhotoCommandExecute()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                Photos.Add(ImageSource.FromStream(() => stream));
                OnPropertyChanged(nameof(HasPhotos));
            }
        }

        private void RemovePhotoCommandExecute(ImageSource photo)
        {
            if (photo != null && Photos.Contains(photo) && Photos.IndexOf(photo) != 0)
            {
                Photos.Remove(photo);
                OnPropertyChanged(nameof(HasPhotos));
                OnPropertyChanged(nameof(CanPickOrTakePhoto));
            }
        }

        public bool IsFirstPhoto(ImageSource photo)
        {
            return Photos.IndexOf(photo) == 0;
        }

        private async Task ClassifyPhotoAsync(FileResult photo)
        {
            if (photo is { })
            {
                IsRunning = true;
                ClassifiedCar = new SmarterCar();
                var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
                Photos.Add(ImageSource.FromStream(() => new MemoryStream(resizedPhoto)));
                OnPropertyChanged(nameof(HasPhotos));

                var result = await CustomVisionService.ClassifyImageAsync(new MemoryStream(resizedPhoto));
                var percent = result?.Probability.ToString("P1");
                if (result.TagName.Equals("Negative"))
                {
                    ClassifiedCar.Name = "Dit is geen Audi.";
                }
                else
                {
                    ClassifiedCar = SmartCarService.GetSmartCarByTag(result.TagName)!;
                    ClassifiedCar.Name += " " + percent;
                }

                OnPropertyChanged(nameof(CanPickOrTakePhoto));
                IsRunning = false;
            }
        }
    }
}