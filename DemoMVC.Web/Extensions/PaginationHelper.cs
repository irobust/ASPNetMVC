using DemoMVC.Web.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace DemoMVC.Web.Extensions
{
    public static class PaginationHelper
    {
        public static string PageLinks(this IHtmlHelper helper, IViewModel viewModel, Func<int, string> pageUrl)
        {
            //StringBuilder result = new StringBuilder();
            //for (int i = 1; i < viewModel.PagingInfo.TotalItems; i++)
            //{
            //    TagBuilder tag = new TagBuilder("a");
            //    tag.MergeAttribute("href", pageUrl(i));
            //    tag.InnerHtml = i.ToString();
            //    if(i == viewModel.PagingInfo.CurrentPage)
            //    {
            //        tag.AddCssClass("Selected");
            //        tag.AddCssClass("btn-primary");
            //    }
            //    tag.AddCssClass("btn btn-default");
            //    result.Append(tag.ToString());
            //}

            return $"current page is {viewModel.PagingInfo.CurrentPage}";
            //return result;

        }
    }
}
