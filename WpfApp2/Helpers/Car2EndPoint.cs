using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Helpers
{

    public class Car2EndPoint : ICar2EndPoint
    {
        private readonly IAPIHelper _aPIHelper;
        public Car2EndPoint(IAPIHelper aPIHelper)
        {
            _aPIHelper = aPIHelper;
        }
        public async Task<List<Car>> GetAll()
        {
            using (HttpResponseMessage responseMessage = await _aPIHelper.ApiClient.GetAsync("api/Cars/nowe"))
            {
                var result = await responseMessage.Content.ReadAsAsync<List<Car>>();
                return result;
            }
        }
    }
}
