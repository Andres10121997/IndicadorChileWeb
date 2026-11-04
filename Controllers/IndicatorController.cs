using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    public class IndicatorController : BaseController
    {
        #region Interfaces
        private readonly ILogger<IndicatorController> logger;
        #endregion



        #region Constructor Method
        public IndicatorController(ILogger<IndicatorController> Logger)
            : base(ControllerName: "Indicador")
        {
            this.logger = Logger;
        }
        #endregion



        #region Views
        public async Task<ActionResult> Index()
        {
            await this.IndexContentAsync();
            
            return this.View();
        }
        #endregion



        #region Content
        public async Task IndexContentAsync()
        {
            string action = "Index";

            await Task.WhenAll(
                this.ViewDataKeywordsAsync(
                    Keywords: new string[]
                    {
                        action,
                        this.ControllerName
                    }
                ),
                this.ViewDataTitleAsync(ActionName: action)
            );
        }
        #endregion
    }
}