using Microsoft.AspNetCore.Mvc;

namespace IndicadorChileWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Variables
        private string title;

        #region Read Only
        private readonly string controllerName;
        #endregion
        #endregion



        public BaseController(string ControllerName)
            : base()
        {
            this.controllerName = ControllerName;
            this.title = string.Empty;
        }



        #region Field
        public string ControllerName
        {
            get => this.controllerName;
        }

        [ViewData]
        public string Title
        {
            get => this.title;
        }
        #endregion



        protected void ViewDataTitle(string ActionName)
        {
            this.title = $"{this.controllerName} - {ActionName}";
        }
    }
}