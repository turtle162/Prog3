using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class BrandAdd : IBrandAdd
    {

        public string Name { get; set; }
        public string Country { get; set; }
        public string Owner { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
