using DemoMVC.Web.Models;

namespace DemoMVC.Web.Interfaces
{
    public interface IInmemoryProducts
    {
        public Product[] GetAll();
    }
}