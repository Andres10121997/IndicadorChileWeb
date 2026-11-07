using IndicadorChileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    [
        AutoValidateAntiforgeryToken,
        RequireHttps
    ]
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
            await this.IndexViewDataAsync();
            
            return this.View();
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
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
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
        #endregion
    }
}