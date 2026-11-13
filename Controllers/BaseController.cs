using IndicadorChileWeb.App.Interfaces.ViewData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    public abstract class BaseController : Controller, IViewDataKeywords, IViewDataTitle
    {
        #region Variables
        private string actionName;
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
            this.actionName = string.Empty;
            this.controllerName = ControllerName;
            this.title = string.Empty;
            this.keywords = string.Empty;
        }
        #endregion



        #region Field
        protected string ActionName
        {
            get => this.actionName;
            set => this.actionName = value;
        }
        
        protected string ControllerName
        {
            get => this.controllerName;
        }

        [ViewData]
        public string Keywords
        {
            get => this.keywords;
        }

        [ViewData]
        public string Title
        {
            get => $"Indicadores de Chile | {this.title}";
        }
        #endregion



        #region View Data
        [NonAction]
        public async Task ViewDataKeywordsAsync(string[] Keywords)
        {
            await Task.Run(
                function: () => this.keywords = string.Join(
                    separator: ", ",
                    value: Keywords
                )
            );
        }

        [NonAction]
        public async Task ViewDataTitleAsync(string[] Titles)
        {
            await Task.Run(
                function: () => this.title = string.Join(
                    separator: " - ",
                    value: Titles
                )
            );
        }
        #endregion
    }
}