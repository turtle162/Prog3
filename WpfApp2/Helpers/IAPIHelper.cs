using System.Net.Http;

namespace WpfApp2.Helpers
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; set; }
    }
}