using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Helpers;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class Car2ViewModel : Screen
    {
        ICar2EndPoint _car2EndPoint;
        public Car2ViewModel(ICar2EndPoint car2EndPoint)
        {
            _car2EndPoint = car2EndPoint;
        }

        protected override async void OnViewLoaded(object view)
        {

            base.OnViewLoaded(view);

            await LoadCar();


        }
        public async Task LoadCar()
        {
            var CarList = await _car2EndPoint.GetAll();
            Cars = new BindingList<Car>(CarList);

        }
        private BindingList<Car> _cars;
        public BindingList<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                NotifyOfPropertyChange(() => Cars);
            }

        }
    }

}
