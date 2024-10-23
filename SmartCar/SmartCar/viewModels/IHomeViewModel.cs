using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartCar.Models;

namespace SmartCar.viewModels
{
    public interface IHomeViewModel
    {
        ICommand PickPhotoCommand { get; set; }
        ICommand TakePhotoCommand { get; set; }
        ICommand AddPhotoCommand { get; set; }
        ICommand RemovePhotoCommand { get; set; }
        ICommand ShowAddPhotoMenuCommand { get; set; }
        ICommand SaveAllInfoCommand { get; set; }


        SmarterCar ClassifiedCar { get; set; }

        bool IsRunning { get; set; }
        bool IsCarClassified { get; set; }
        bool HasPhotos { get; }
        bool CanPickOrTakePhoto { get; }
        ObservableCollection<ImageSource> Photos { get; set; }
    }
}
