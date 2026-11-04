using IndicadorChileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    public class HomeController : BaseController
    {
        #region Interfaces
        private readonly ILogger<HomeController> logger;
        #endregion



        #region Constructor Method
        public HomeController(ILogger<HomeController> Logger)
            : base(ControllerName: "Principal")
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
            
            return View();
        }

        [
            ResponseCache(
                Duration = 0,
                Location = ResponseCacheLocation.None,
                NoStore = true
            )
        ]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion



        #region Content
        private async Task IndexContentAsync()
        {
            string action = "Index";

            await Task.WhenAll(
                this.ViewDataKeywordsAsync(
                    Keywords: new string[]
                    {
                        this.ControllerName,
                        action
                    }
                ),
                this.ViewDataTitleAsync(ActionName: action)
            );
        }
        #endregion
    }
}