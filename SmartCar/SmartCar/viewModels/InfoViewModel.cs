using CommunityToolkit.Mvvm.ComponentModel;
using SmartCar.Models;
using SmartCar.Services;
using SmartCar.viewModels;
using System.Collections.ObjectModel;

namespace SmartCar.ViewModels
{
    public class InfoViewModel : ObservableObject, IInfoViewModel
    {
        private readonly IStorageService _storageService;

        public ObservableCollection<SmarterCar> Cars { get; } = new ObservableCollection<SmarterCar>();

        public InfoViewModel(IStorageService storageService)
        {
            _storageService = storageService;
            LoadCars();
        }

        public async void LoadCars()
        {
            var cars = await _storageService.GetAllCarsAsync();
            foreach (var car in cars)
            {
                Cars.Add(car);
                Console.WriteLine($"Car loaded: {car.Name}"); // Debug output
            }

            Console.WriteLine($"Total cars loaded: {Cars.Count}"); // Total count debug output
        }
    }
}
