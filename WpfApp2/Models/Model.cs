using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Model : IModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public DateTime FirstDateProduction { get; set; }
        public string Brand_ { get; set; }

    }
}
