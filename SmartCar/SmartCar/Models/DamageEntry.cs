﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCar.Models
{
    public class DamageEntry : ObservableObject
    {
        private string damageType;
        public string DamageType
        {
            get => damageType;
            set
            {
                SetProperty(ref damageType, value);
                OnPropertyChanged(nameof(IsDamageTypeSelected));
            }
        }

        private string damageSeverity;
        public string DamageSeverity
        {
            get => damageSeverity;
            set => SetProperty(ref damageSeverity, value);
        }

        public bool IsDamageTypeSelected => !string.IsNullOrEmpty(DamageType);
    }
}
