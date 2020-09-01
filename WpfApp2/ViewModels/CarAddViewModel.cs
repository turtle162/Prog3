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
    public class CarAddViewModel : Screen
    {
        ICar2EndPoint _car2EndPoint;
        private readonly AddedViewModel _addedViewModel;
        private readonly IWindowManager _windowManager;
        public CarAddViewModel(ICar2EndPoint car2EndPoint, AddedViewModel addedViewModel, IWindowManager windowManager)
        {
            _car2EndPoint = car2EndPoint;
            _addedViewModel = addedViewModel;
            _windowManager = windowManager;
           

        }
       
        private int _ModelId { get; set; }
        private string _Id { get; set; }
        private DateTime _DateProduction { get; set; }
        private string _FuelType { get; set; }
        private string _BodyStyle { get; set; }
        private int _OdoMeter { get; set; }
        private string _EngineType { get; set; }
        public DateTime DateProduction
        {
            get { return _DateProduction; }
            set
            {
                _DateProduction = value;
                NotifyOfPropertyChange(() => DateProduction);
            }
        }
        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        public string FuelType
        {
            get { return _FuelType; }
            set
            {
                _FuelType = value;
                NotifyOfPropertyChange(() => FuelType);
            }
        }
        public string BodyStyle
        {
            get { return _BodyStyle; }
            set
            {
                _BodyStyle = value;
                NotifyOfPropertyChange(() => BodyStyle);
            }
        }
        public int ModelId
        {
            get { return _ModelId; }
            set
            {
                _ModelId = value;
                NotifyOfPropertyChange(() => ModelId);
            }
        }
        public int OdoMeter
        {
            get { return _OdoMeter; }
            set
            {
                _OdoMeter = value;
                NotifyOfPropertyChange(() => OdoMeter);
            }
        }
        public string EngineType
        {
            get { return _EngineType; }
            set
            {
                _EngineType = value;
                NotifyOfPropertyChange(() => EngineType);
            }
        }
        public async Task AddCar()
        {

            CarAdd car = new CarAdd()
            {
                BodyStyle = this.BodyStyle,
                DateProduction = this.DateProduction,
                EngineType = this.EngineType,
                FuelType = this.FuelType,
                Id = this.Id,
                ModelId = this.ModelId,
                OdoMeter = this.OdoMeter


            };
            //
            try
            {
                await _car2EndPoint.PostCar(car);
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
