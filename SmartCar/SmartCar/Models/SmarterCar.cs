using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

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

        private double price;
        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        private double oldPrice;
        public double OldPrice
        {
            get => oldPrice;
            set => SetProperty(ref oldPrice, value);
        }

        private double newPrice;
        public double NewPrice
        {
            get => newPrice;
            set => SetProperty(ref  newPrice, value);
        }

        private Specs specs = new Specs();
        public Specs Spec
        {
            get => specs;
            set => SetProperty(ref specs, value);
        }

        private bool isDamaged;
        public bool IsDamaged
        {
            get => isDamaged;
            set => SetProperty(ref isDamaged, value);
        }

        private string kmAmount;
        public string KmAmount
        {
            get => kmAmount;
            set => SetProperty(ref kmAmount, value);
        }

        private string yearBought;
        public string YearBought
        {
            get => yearBought;
            set => SetProperty(ref yearBought, value);
        }

        private string damages;
        public string Damages
        {
            get => damages;
            set => SetProperty(ref damages, value);
        }

        private ObservableCollection<string> damageTypes;
        public ObservableCollection<string> DamageTypes
        {
            get => damageTypes;
            set => SetProperty(ref damageTypes, value);
        }

        private string selectedDamageType;
        public string SelectedDamageType
        {
            get => selectedDamageType;
            set
            {
                SetProperty(ref selectedDamageType, value);
                IsDamageTypeSelected = !string.IsNullOrEmpty(value);
                DamageSeverities = new ObservableCollection<string> { "Minor", "Moderate", "Severe","Critical" }; // Example severities
            }
        }

        private ObservableCollection<string> damageSeverities;
        public ObservableCollection<string> DamageSeverities
        {
            get => damageSeverities;
            set => SetProperty(ref damageSeverities, value);
        }

        private string selectedDamageSeverity;
        public string SelectedDamageSeverity
        {
            get => selectedDamageSeverity;
            set => SetProperty(ref selectedDamageSeverity, value);
        }

        private bool isDamageTypeSelected;
        public bool IsDamageTypeSelected
        {
            get => isDamageTypeSelected;
            set => SetProperty(ref isDamageTypeSelected, value);
        }

        private ObservableCollection<ImageSource> photos = new ObservableCollection<ImageSource>();
        public ObservableCollection<ImageSource> Photos
        {
            get => photos;
            set => SetProperty(ref photos, value);
        }

        public SmarterCar()
        {
            DamageTypes = new ObservableCollection<string> { "Scratch", "Dent", "Crack" }; // Example types
        }
    }
}
