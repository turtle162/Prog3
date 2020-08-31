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
    public class BrandViewModel : Screen
    {
        IBrandEndPoint _brandEndPoint;
        public BrandViewModel(IBrandEndPoint brandEndPoint)
        {
            _brandEndPoint = brandEndPoint;
        }

        protected override async void OnViewLoaded(object view)
        {

            base.OnViewLoaded(view);

            await LoadModel();


        }
        public async Task LoadModel()
        {
            var BrandList = await _brandEndPoint.GetAll();
            Brands = new BindingList<Brand>(BrandList);

        }
        private BindingList<Brand> _brands;
        public BindingList<Brand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                NotifyOfPropertyChange(() => Brands);
            }

        }
    }

}
