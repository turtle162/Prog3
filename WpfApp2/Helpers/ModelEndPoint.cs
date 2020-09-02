using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Helpers
{

    public class ModelEndPoint : IModelEndPoint
    {
        private readonly IAPIHelper _aPIHelper;
        public ModelEndPoint(IAPIHelper aPIHelper)
        {
            _aPIHelper = aPIHelper;
        }
        public async Task<List<Model>> GetAll()
        {
            using (HttpResponseMessage responseMessage = await _aPIHelper.ApiClient.GetAsync("api/Models/nowe"))
            {
                var result = await responseMessage.Content.ReadAsAsync<List<Model>>();
                return result;
            }
        }
        public async Task PostModel(ModelAdd model)
        {
            using (HttpResponseMessage responseMessage = await _aPIHelper.ApiClient.PostAsJsonAsync("api/Models/nowe2", model))
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
