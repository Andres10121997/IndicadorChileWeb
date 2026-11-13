using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndicadorChileWeb.App.Interfaces.ViewData
{
    public interface IViewDataKeywords
    {
        [ViewData]
        protected string Keywords { get; }

        [NonAction]
        protected Task ViewDataKeywordsAsync(string[] Keywords);
    }
}