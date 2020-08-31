using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Helpers
{
    public interface ICar2EndPoint
    {
        Task<List<Car>> GetAll();
    }
}