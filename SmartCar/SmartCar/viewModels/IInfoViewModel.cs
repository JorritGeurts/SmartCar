using SmartCar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCar.viewModels
{
    public interface IInfoViewModel
    {
        ObservableCollection<SmarterCar> Cars { get; }
        void LoadCars();

    }
}
