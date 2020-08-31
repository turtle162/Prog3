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
    public class ModelViewModel : Screen
    {
        IModelEndPoint _modelEndPoint;
        public ModelViewModel(IModelEndPoint modelEndPoint)
        {
            _modelEndPoint = modelEndPoint;
        }

        protected override async void OnViewLoaded(object view)
        {

            base.OnViewLoaded(view);

            await LoadModel();


        }
        public async Task LoadModel()
        {
            var ModelList = await _modelEndPoint.GetAll();
            Models = new BindingList<Model>(ModelList);

        }
        private BindingList<Model> _models;
        public BindingList<Model> Models
        {
            get { return _models; }
            set
            {
                _models = value;
                NotifyOfPropertyChange(() => Models);
            }

        }
    }

}
