using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SmartCar.Models;
using SmartCar.Services;
using SmartCar.viewModels;

namespace SmartCar.ViewModels
{
    public class InfoViewModel : ObservableObject, IInfoViewModel
    {
        private readonly IStorageService _storageService;

        public ObservableCollection<SmarterCar> Cars { get; } = new ObservableCollection<SmarterCar>();

        public InfoViewModel(IStorageService storageService, INavigationService navigationService)
        {
            _storageService = storageService;
            Console.WriteLine("InfoViewModel aangemaakt"); // Debug output
            LoadCars();
        }
        
        public async void LoadCars()
        {
            var cars = await _storageService.GetAllCarsAsync();
            foreach (var car in cars)
            {
                Cars.Add(car);
                Console.WriteLine($"Auto geladen: {car.Name}"); // Debug output
            }

            Console.WriteLine($"Totaal aantal auto's geladen: {Cars.Count}"); // Total count debug output
        }
    }

}
