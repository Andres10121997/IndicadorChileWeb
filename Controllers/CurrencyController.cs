using IndicadorChileWeb.App;
using IndicadorChileWeb.App.DTO.Currency;
using IndicadorChileWeb.Context;
using IndicadorChileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    [
        AutoValidateAntiforgeryToken,
        Route(
            template: "[controller]"
        ),
        RequireHttps
    ]
    public class CurrencyController : BaseController
    {
        #region Interfaces
        private readonly ILogger<CurrencyController> logger;
        #endregion



        #region Constructor Method
        public CurrencyController(ILogger<CurrencyController> Logger)
            : base(ControllerName: "Indicador")
        {
            this.logger = Logger;
        }
        #endregion



        #region Views
        [
            HttpGet
        ]
        public async Task<ActionResult> Index()
        {
            await this.ViewDataIndexAsync();
            
            return this.View();
        }

        [
            HttpGet(
                template: "[action]"
            )
        ]
        public async Task<ActionResult> Search([FromQuery] SearchFilterModel SearchFilter)
        {
            #region Objects
            ContextBase contextBase;
            Result<CurrencyHeaderDTO<float>, Exception> currency;
            #endregion

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(
                    actionName: "Index",
                    controllerName: "Currency",
                    routeValues: new
                    {
                        area = ""
                    }
                );
            }

            #region Init
            contextBase = new ContextBase();
            currency = await contextBase.GetCurrencyList(SearchFilter);
            #endregion

            await this.ViewDataSearchAsync();

            if (currency.IsSuccess)
            {
                this.logger.LogInformation(
                    message: "Lista de divisas",
                    args: currency.Value
                );
            }
            else
            {
                this.logger.LogError(
                    exception: currency.Error,
                    message: "Error al obtener la lista de divisas"
                );
            }

            return this.View();
        }
        #endregion



        #region View Data
        [
            NonAction
        ]
        private async Task ViewDataIndexAsync()
        {
            this.ActionName = "Index";

            await Task.WhenAll(
                this.ViewDataKeywordsAsync(
                    Keywords: new string[2]
                    {
                        this.ControllerName,
                        this.ActionName
                    }
                ),
                this.ViewDataTitleAsync(
                    Titles: new string[2]
                    {
                        this.ControllerName,
                        this.ActionName
                    }
                )
            );
        }

        [
            NonAction
        ]
        private async Task ViewDataSearchAsync()
        {
            this.ActionName = "Buscar";

            await Task.WhenAll(
                this.ViewDataKeywordsAsync(
                    Keywords: new string[2]
                    {
                        this.ControllerName,
                        this.ActionName
                    }
                ),
                this.ViewDataTitleAsync(
                    Titles: new string[2]
                    {
                        this.ControllerName,
                        this.ActionName
                    }
                )
            );
        }
        #endregion
    }
}