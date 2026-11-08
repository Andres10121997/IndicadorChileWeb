using IndicadorChileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    [
        AutoValidateAntiforgeryToken,
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
            await this.IndexViewDataAsync();
            
            return this.View();
        }

        [
            HttpGet
        ]
        public async Task<ActionResult> Search()
        {
            await this.SearchViewDataAsync();
            
            return this.View();
        }

        [
            HttpGet(
                template: "[action]/{id}"
            )
        ]
        public async Task<ActionResult> Search(SearchFilterModel SearchFilter)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.SearchViewDataAsync();

            return this.View();
        }
        #endregion



        #region View Data
        [NonAction]
        private async Task IndexViewDataAsync()
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
                    ActionName: this.ActionName
                )
            );
        }

        [NonAction]
        private async Task SearchViewDataAsync()
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
                    ActionName: this.ActionName
                )
            );
        }
        #endregion
    }
}