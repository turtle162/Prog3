using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Helpers
{
    public interface IBrandEndPoint
    {
        Task<List<Brand>> GetAll();
        Task PostBrand(BrandAdd brand);
    }
}