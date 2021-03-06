﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private CarViewModel _carViewModel;
        public ShellViewModel(CarViewModel carViewModel)
        {
            _carViewModel = carViewModel;
            ActivateItem(_carViewModel);
        }
    }
}
