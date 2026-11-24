using IndicadorChileWeb.App;
using IndicadorChileWeb.App.DTO.Currency;
using IndicadorChileWeb.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Context
{
    public class ContextBase
    {
        #region Constructor Method
        public ContextBase()
            : base()
        {
            
        }
        #endregion



        public async Task< Result< CurrencyHeaderDTO<float>, Exception > > GetCurrencyList(SearchFilterModel SearchFilter)
        {
            using (HttpClient client = new HttpClient())
            {
                #region Objects
                Uri url;
                HttpRequestMessage request;
                #endregion

                #region Init
                url = new Uri(
                    uriString: $"https://localhost:32771/api/SII/GetCurrencyList?CurrencyType={SearchFilter.CurrencyType}&Year={SearchFilter.Year}&Month={SearchFilter.Month}"
                );

                request = new HttpRequestMessage(
                    method: HttpMethod.Get,
                    requestUri: url
                );
                #endregion

                request.Headers.Accept.Add(
                    item: new MediaTypeWithQualityHeaderValue(mediaType: "application/json")
                );

                try
                {
                    using (HttpResponseMessage response = await client.SendAsync(request: request))
                    {
                        #region Objects
                        CurrencyHeaderDTO<float> responseContent;
                        #endregion

                        responseContent = await response.Content.ReadFromJsonAsync<CurrencyHeaderDTO<float>>()
                                          ??
                                          throw new ArgumentNullException(
                                              paramName: nameof(response)
                                          );

                        return Result<CurrencyHeaderDTO<float>, Exception>.Success(responseContent);
                    }
                }
                catch (ArgumentNullException ane)
                {
                    return Result<CurrencyHeaderDTO<float>, Exception>.Failure(
                        Error: ane
                    );
                }
                catch (InvalidOperationException ioe)
                {
                    return Result<CurrencyHeaderDTO<float>, Exception>.Failure(
                        Error: ioe
                    );
                }
                catch (HttpRequestException hre)
                {
                    return Result<CurrencyHeaderDTO<float>, Exception>.Failure(
                        Error: hre
                    );
                }
                catch (OperationCanceledException oce)
                {
                    return Result<CurrencyHeaderDTO<float>, Exception>.Failure(
                        Error: oce
                    );
                }
            }
        }
    }
}