using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Helpers;

namespace WpfApp2.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<Inside2>
    {
        
        private IEventAggregator _events;
        private Car2ViewModel _car2ViewModel;
        private SimpleContainer _container;

        public ShellViewModel( IEventAggregator events, Car2ViewModel car2ViewModel,
            SimpleContainer container)
        {
            _events = events;
            _car2ViewModel = car2ViewModel;
            _container = container;
            _events.Subscribe(this);
            ActivateItem(IoC.Get<CarViewModel>());
           
            
        }

        public void Handle(Inside2 message)
        {
            ActivateItem(_car2ViewModel);
            
        }
    }
}
