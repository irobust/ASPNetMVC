using DemoMVC.Web.Models;

namespace DemoMVC.Web.Interfaces
{
    public interface IViewModel
    {
        public PagingInfo PagingInfo { get; set; }
    }
}
