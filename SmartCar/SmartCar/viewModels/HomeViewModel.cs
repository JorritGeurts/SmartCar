using CommunityToolkit.Mvvm.ComponentModel;
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
    public class HomeViewModel : ObservableObject, IHomeViewModel
    {
        
        private bool isRunning = false;
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }
        private bool isCarClassified = false;
        public bool IsCarClassified
        {
            get => isCarClassified;
            set => SetProperty(ref isCarClassified, value);
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
        public ICommand SaveAllInfoCommand { get; set; }
        private IStorageService _storageService;
        private INavigationService _navigationService;

        public HomeViewModel(IStorageService storageService, INavigationService navigationService)
        {
            BindCommands();
            _storageService = storageService;
            _navigationService = navigationService;
        }

        private void BindCommands()
        {
            PickPhotoCommand = new AsyncRelayCommand(PickAndClassifyPhoto);
            TakePhotoCommand = new AsyncRelayCommand(TakeAndClassifyPhoto);
            ShowAddPhotoMenuCommand = new RelayCommand(ShowAddPhotoMenu);
            AddPhotoCommand = new AsyncRelayCommand(AddPhotoCommandExecute);
            RemovePhotoCommand = new RelayCommand<ImageSource>(RemovePhotoCommandExecute);
            SaveAllInfoCommand = new AsyncRelayCommand(SaveAllInfoAndNavigate);
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

        private async Task SaveAllInfoAndNavigate()
        {
            try
            {
                await _navigationService.NavigateToInfoPageAsync(ClassifiedCar);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij opslaan en navigeren: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to save data: {ex.Message}", "OK");
            }
        }

        private void RecalculatePrice()
        {
            double basePrice = ClassifiedCar.Price;
            double newPrice = basePrice;
            if (ClassifiedCar.IsDamaged)
            {
                newPrice *= 0.8;
            }

            foreach (var damage in ClassifiedCar.DamageTypes)
            {
                newPrice *= 0.9;
            }
            ClassifiedCar.OldPrice = basePrice;
            ClassifiedCar.NewPrice = newPrice;
            OnPropertyChanged(nameof(ClassifiedCar) );
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
                if (result.TagName.Equals("Negative"))
                {
                    ClassifiedCar.Name = "Dit is geen Audi.";
                }
                else
                {
                    ClassifiedCar = SmartCarService.GetSmartCarByTag(result.TagName)!;
                    ClassifiedCar.Name += " ";
                }
                IsCarClassified = true;
                OnPropertyChanged(nameof(CanPickOrTakePhoto));
                IsRunning = false;
                RecalculatePrice();
            }
        }
    }
}
