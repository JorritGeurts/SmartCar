using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SafariSnap.Services;
using SmartCar.Models;
using SmartCar.Services;
using System.Windows.Input;

namespace SmartCar.viewModels
{
    public class InfoViewModel : ObservableObject, IInfoViewModel
    {
        private bool isRunning = false;
        

        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }
        private ImageSource photo;

        public ImageSource Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }

        private SmarterCar classifiedCar;

        public SmarterCar ClassifiedCar
        {
            get => classifiedCar;
            set => SetProperty(ref classifiedCar, value);
        }

        public ICommand PickPhotoCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }

        public InfoViewModel()
        {
            BindCommands();
        }

        private void BindCommands()
        {
            PickPhotoCommand = new AsyncRelayCommand(PickAndClassifyPhoto);
            TakePhotoCommand = new AsyncRelayCommand(TakeAndClassifyPhoto);
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

        private async Task ClassifyPhotoAsync(FileResult photo)
        {
            if (photo is { })
            {
                IsRunning = true;

                ClassifiedCar = new SmarterCar();

                // Resize to allowed size - 4MB
                var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
                Photo = ImageSource.FromStream(() => new MemoryStream(resizedPhoto));

                // Custom Vision API call
                var result = await CustomVisionService.ClassifyImageAsync(new MemoryStream(resizedPhoto));
                // Change the percentage notation from 0.9 to display 90.0%
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

                IsRunning = false;
            }
        }
    }
}
