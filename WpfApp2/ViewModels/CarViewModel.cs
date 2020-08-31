using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Helpers;

namespace WpfApp2.ViewModels
{
    public class CarViewModel  : Screen
    {
        private IAPIHelper _aPIHelper;
        private IEventAggregator _events;
        public void Inside()
        {
            _events.PublishOnUIThread(new Inside2());
        }
        public CarViewModel(IAPIHelper apihelper, IEventAggregator events)
        {
            _aPIHelper = apihelper;
            _events = events;
        }
    }
}
