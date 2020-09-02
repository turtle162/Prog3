using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Helpers
{

    public class BrandEndPoint : IBrandEndPoint
    {
        private readonly IAPIHelper _aPIHelper;
        public BrandEndPoint(IAPIHelper aPIHelper)
        {
            _aPIHelper = aPIHelper;
        }
        public async Task<List<Brand>> GetAll()
        {
            using (HttpResponseMessage responseMessage = await _aPIHelper.ApiClient.GetAsync("api/Brands"))
            {
                var result = await responseMessage.Content.ReadAsAsync<List<Brand>>();
                return result;
            }
        }
        public async Task PostBrand(BrandAdd brand)
        {
            using (HttpResponseMessage responseMessage = await _aPIHelper.ApiClient.PostAsJsonAsync("api/Brands", brand))
            {
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //ActivateItem(IoC.Get<Car2ViewModel>());
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
