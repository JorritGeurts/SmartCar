using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartCar.Models
{
    public class Specs : ObservableObject
    {
        private string engine = string.Empty;
        public string Engine
        {
            get => engine;
            set => SetProperty(ref engine, value);
        }

        private string acceleration = string.Empty;
        public string Acceleration
        {
            get => acceleration;
            set => SetProperty(ref acceleration, value);
        }

        private string transmission = string.Empty;
        public string Transmission
        {
            get => transmission;
            set => SetProperty(ref transmission, value);
        }
    }
}
