using System.Net.Http;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Context
{
    public class Context
    {
        public async void GetCurrencyList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:32779/api/SII/GetCurrencyList");

                using (HttpResponseMessage response = await client.SendAsync(request))
                {

                }
            }
        }
    }
}