using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndicadorChileWeb.App.Interfaces.ViewData
{
    public interface IViewDataTitle
    {
        [ViewData]
        protected string Title { get; }

        [NonAction]
        protected Task ViewDataTitleAsync(string[] Titles);
    }
}