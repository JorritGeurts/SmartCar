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
            set => SetProperty(ref newPrice, value);
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
            set
            {
                if (SetProperty(ref kmAmount, value))
                {
                    Validate();
                }
            }
        }

        private string yearBought;
        public string YearBought
        {
            get => yearBought;
            set
            {
                if (SetProperty(ref yearBought, value))
                {
                    Validate();
                }
            }
        }

        private ObservableCollection<DamageEntry> damageEntries = new ObservableCollection<DamageEntry>();
        public ObservableCollection<DamageEntry> DamageEntries
        {
            get => damageEntries;
            set => SetProperty(ref damageEntries, value);
        }

        private ObservableCollection<string> damageTypes;
        public ObservableCollection<string> DamageTypes
        {
            get => damageTypes;
            set => SetProperty(ref damageTypes, value);
        }

        private ObservableCollection<string> damageSeverities;
        public ObservableCollection<string> DamageSeverities
        {
            get => damageSeverities;
            set => SetProperty(ref damageSeverities, value);
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
            DamageSeverities = new ObservableCollection<string> { "Minor", "Moderate", "Severe", "Critical" }; // Example severities
            DamageEntries.Add(new DamageEntry()); // Initialize with one entry
        }

        private bool canSave;
        public bool CanSave
        {
            get => canSave;
            private set => SetProperty(ref canSave, value);
        }

        private void Validate()
        {
            CanSave = !string.IsNullOrWhiteSpace(KmAmount) && !string.IsNullOrWhiteSpace(YearBought);
        }
    }
}
