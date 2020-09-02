using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Helpers;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class BrandAddViewModel : Screen
    {
        IBrandEndPoint _brandEndPoint;
        private readonly AddedViewModel _addedViewModel;
        private readonly IWindowManager _windowManager;
        public BrandAddViewModel(IBrandEndPoint brandEndPoint, AddedViewModel addedViewModel, IWindowManager windowManager)
        {
            _brandEndPoint = brandEndPoint;
            _addedViewModel = addedViewModel;
            _windowManager = windowManager;
           

        }

        private string _Name { get; set; }
        private string _Country { get; set; }
        private string _Owner { get; set; }
        private DateTime _DateCreated { get; set; }

       
        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set
            {
                _DateCreated = value;
                NotifyOfPropertyChange(() => DateCreated);
            }
        }
        public string Name2
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyOfPropertyChange(() => Name2);
            }
        }
        public string Owner
        {
            get { return _Owner; }
            set
            {
                _Owner = value;
                NotifyOfPropertyChange(() => Owner);
            }
        }
        public string Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                NotifyOfPropertyChange(() => Country);
            }
        }

        public async Task AddBrand()
        {

            BrandAdd brand = new BrandAdd()
            {
                Name = this.Name2,
                Country = this.Country,
                Owner = this.Owner,
                DateCreated = this.DateCreated


            };
            //
            try
            {
                await _brandEndPoint.PostBrand(brand);
                _addedViewModel.UpdateMessage("Komunikat", "Dodano rekord");
                _windowManager.ShowWindow(_addedViewModel);
            }
            catch
            {
                _addedViewModel.UpdateMessage("Ostrzeżenie", "Nie dodano rekord");
                _windowManager.ShowWindow(_addedViewModel);
            }
           
        }
    }
}
