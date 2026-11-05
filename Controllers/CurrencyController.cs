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
            await this.IndexContentAsync();
            
            return this.View();
        }
        #endregion



        #region Content
        [NonAction]
        public async Task IndexContentAsync()
        {
            this.ActionName = "Index";

            await Task.WhenAll(
                this.ViewDataKeywordsAsync(
                    Keywords: new string[]
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