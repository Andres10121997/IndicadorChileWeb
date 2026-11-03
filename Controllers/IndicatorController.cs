using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public ActionResult Index()
        {
            this.IndexContent();
            
            return this.View();
        }
        #endregion



        #region Content
        public void IndexContent()
        {
            this.ViewDataTitle(ActionName: "Index");
        }
        #endregion
    }
}