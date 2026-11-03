using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IndicadorChileWeb.Controllers
{
    public class PropertyController : BaseController
    {
        #region Interfaces
        private readonly ILogger<PropertyController> logger;
        #endregion



        #region Constructor Method
        public PropertyController(ILogger<PropertyController> Logger)
            : base(ControllerName: "Propiedad")
        {
            this.logger = Logger;
        }
        #endregion



        #region Views
        public IActionResult Add()
        {
            this.AddContent();
            
            return View();
        }
        #endregion



        private void AddContent()
        {
            this.ViewDataTitle(ActionName: "Agregar");
        }
    }
}