using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private CarViewModel _carVM;
        public ShellViewModel(CarViewModel carVM)
        {
            _carVM = carVM;
            ActivateItem(_carVM);
        }
    }
}
