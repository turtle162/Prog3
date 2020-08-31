using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Brand
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Owner { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
