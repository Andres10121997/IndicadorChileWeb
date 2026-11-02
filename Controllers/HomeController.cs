using IndicadorChileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace IndicadorChileWeb.Controllers
{
    public class HomeController : Controller
    {
        #region Interfaces
        private readonly ILogger<HomeController> logger;
        #endregion



        public HomeController(ILogger<HomeController> Logger)
            : base()
        {
            this.logger = Logger;
        }



        #region Views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}