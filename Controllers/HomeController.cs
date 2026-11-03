using IndicadorChileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
        public ActionResult Index()
        {
            this.IndexContent();
            
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
        private void IndexContent()
        {
            this.ViewDataTitle(ActionName: "Index");
            this.ViewDataKeywords(
                Keywords: new string[]
                {
                    this.ControllerName
                }
            );
        }
        #endregion
    }
}