using Microsoft.AspNetCore.Mvc;
using System;

namespace IndicadorChileWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Variables
        private string title;
        private string keywords;

        #region Read Only
        private readonly string controllerName;
        #endregion
        #endregion



        #region Constructor Method
        public BaseController(string ControllerName)
            : base()
        {
            this.controllerName = ControllerName;
            this.title = string.Empty;
            this.keywords = string.Empty;
        }
        #endregion



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

        [ViewData]
        public string Keywords
        {
            get => this.keywords;
        }
        #endregion



        protected void ViewDataTitle(string ActionName)
        {
            this.title = string.Join(
                separator: " - ",
                value: [this.controllerName, ActionName]
            );
        }

        protected void ViewDataKeywords(string[] Keywords)
        {
            this.keywords = string.Join(
                separator: ", ",
                value: Keywords
            );
        }
    }
}