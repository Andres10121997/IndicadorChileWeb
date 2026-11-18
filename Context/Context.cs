using IndicadorChileWeb.App.DTO.Currency;
using IndicadorChileWeb.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Context
{
    public class Context
    {
        #region Constructor Method
        public Context()
            : base()
        {
            
        }
        #endregion



        public async Task<CurrencyHeaderDTO<float>> GetCurrencyList(SearchFilterModel SearchFilter)
        {
            using (HttpClient client = new HttpClient())
            {
                #region Objects
                Uri url;
                HttpRequestMessage request;
                #endregion

                #region Init
                url = new Uri(
                    uriString: $"https://localhost:32777/api/SII/GetCurrencyList?CurrencyType={SearchFilter.CurrencyType}&Year={SearchFilter.Year}&Month={SearchFilter.Month}"
                );

                request = new HttpRequestMessage(
                    method: HttpMethod.Get,
                    requestUri: url
                );
                #endregion

                request.Headers.Accept.Add(
                    item: new MediaTypeWithQualityHeaderValue(mediaType: "application/json")
                );

                using (HttpResponseMessage response = await client.SendAsync(request: request))
                {
                    var responseContent = await response.Content.ReadFromJsonAsync< CurrencyHeaderDTO<float> >();

                    return responseContent ?? default!;
                }
            }
        }
    }
}