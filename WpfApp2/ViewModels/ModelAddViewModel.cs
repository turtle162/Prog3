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
    public class ModelAddViewModel : Screen
    {
        IModelEndPoint _modelEndPoint;
        private readonly AddedViewModel _addedViewModel;
        private readonly IWindowManager _windowManager;
        public ModelAddViewModel(IModelEndPoint modelEndPoint, AddedViewModel addedViewModel, IWindowManager windowManager)
        {
            _modelEndPoint = modelEndPoint;
            _addedViewModel = addedViewModel;
            _windowManager = windowManager;
           

        }

        private string _Name { get; set; }
        private DateTime _FirstDateProduction { get; set; }
        private string _Brand_ { get; set; }
        
        public string Name2
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyOfPropertyChange(() => Name2);
            }
        }
        public string Brand
        {
            get { return _Brand_; }
            set
            {
                _Brand_ = value;
                NotifyOfPropertyChange(() => Brand);
            }
        }
        public DateTime FirstDateProduction
        {
            get { return _FirstDateProduction; }
            set
            {
                _FirstDateProduction = value;
                NotifyOfPropertyChange(() => FirstDateProduction);
            }
        }

        public async Task AddModel()
        {

            ModelAdd model = new ModelAdd()
            {
               Name = this.Name2,
               Brand_ = this.Brand,
               FirstDateProduction = this.FirstDateProduction


            };
            //
            try
            {
                await _modelEndPoint.PostModel(model);
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
