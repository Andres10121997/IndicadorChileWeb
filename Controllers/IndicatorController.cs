using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IndicadorChileWeb.Controllers
{
    public class IndicatorController : BaseController
    {
        private readonly ILogger<IndicatorController> logger;
        


        public IndicatorController(ILogger<IndicatorController> Logger)
            : base(ControllerName: "Indicador")
        {
            this.logger = Logger;
        }



        public ActionResult Index()
        {
            this.IndexContent();
            
            return this.View();
        }



        public void IndexContent()
        {
            this.ViewDataTitle(ActionName: "Index");
        }
    }
}