using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.ViewModels;

namespace WpfApp2.Helpers
{

    public class Car2EndPoint :  ICar2EndPoint
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
        public async Task PostCar(CarAdd car)
        {
            using (HttpResponseMessage responseMessage = await _aPIHelper.ApiClient.PostAsJsonAsync("api/Cars/nowe2", car))
            {
                if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK )
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
