using DemoMVC.Web.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace DemoMVC.Web.Extensions
{
    public static class PaginationHelper
    {
        public static string PageLinks(this IHtmlHelper helper, IViewModel viewModel, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i < viewModel.PagingInfo.TotalItems; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml.AppendHtml(i.ToString());
                if (i == viewModel.PagingInfo.CurrentPage)
                {
                    a.AddCssClass("Selected");
                    a.AddCssClass("btn-primary");
                }
                a.AddCssClass("btn btn-default");
                result.Append(a.ToString());
            }

            //return $"current page is {viewModel.PagingInfo.CurrentPage}";
            return result.ToString();

        }
    }
}
