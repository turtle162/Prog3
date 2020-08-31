using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace WpfApp2.Helpers
{
    public class APIHelper : IAPIHelper
    {
        public APIHelper()
        {
            InitializedClient();
        }

        public HttpClient ApiClient { get; set; }
        private void InitializedClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://http://localhost:60161/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
