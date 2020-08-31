using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Car : ICar
    {

        public string Id { get; set; }
       

        public DateTime DateProduction { get; set; }
        public string FuelType { get; set; }
        public string BodyStyle { get; set; }
        public int OdoMeter { get; set; }
        public string EngineType { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
