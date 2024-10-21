using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartCar.Models
{
    public class SmarterCar : ObservableObject
    {
        private string tag = string.Empty;
        public string Tag
        {
            get => tag;
            set => SetProperty(ref tag, value);
        }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string price = string.Empty;
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        private Specs specs = new Specs();
        public Specs Spec
        {
            get => specs;
            set => SetProperty(ref specs, value);
        }
    }
}
