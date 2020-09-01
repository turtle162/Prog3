using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ViewModels
{
    public class AddedViewModel : Screen
    {
        public string Header { get; set; }
        public string Message { get; set; }
        public void UpdateMessage(string h, string m)
        {
            Header = h;
            NotifyOfPropertyChange(() => Header);
            Message = m;
            NotifyOfPropertyChange(() => Message);
        }
    }
}
