using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndicadorChileWeb.Controllers
{
    public abstract class BaseController : Controller
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
        public string Title
        {
            get => $"Indicadores de Chile | {this.title}";
        }

        [ViewData]
        public string Keywords
        {
            get => this.keywords;
        }
        #endregion



        #region View Data
        protected async Task ViewDataKeywordsAsync(string[] Keywords)
        {
            await Task.Run(
                function: () => this.keywords = string.Join(
                    separator: ", ",
                    value: Keywords
                )
            );
        }

        protected async Task ViewDataTitleAsync(string ActionName)
        {
            await Task.Run(
                function: () => this.title = string.Join(
                    separator: " - ",
                    value: [
                        this.controllerName,
                        ActionName
                    ]
                )
            );
        }
        #endregion
    }
}