using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Helpers
{
    public interface IModelEndPoint
    {
        Task<List<Model>> GetAll();
        Task PostModel(ModelAdd model);
    }
}