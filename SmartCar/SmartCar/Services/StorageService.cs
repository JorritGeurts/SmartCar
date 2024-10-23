using SmartCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCar.Services
{
    public class StorageService : IStorageService
    {
        private readonly List<SmarterCar> _cars = new List<SmarterCar>();

        public Task SaveCarAsync(SmarterCar car)
        {
            _cars.Add(car);
            Console.WriteLine($"Auto opgeslagen: {car.Name}"); // Debug output
            return Task.CompletedTask;
        }

        public Task<List<SmarterCar>> GetAllCarsAsync()
        {
            Console.WriteLine($"Ophalen van {_cars.Count} auto's"); // Debug output
            return Task.FromResult(_cars);
        }
    }

}
