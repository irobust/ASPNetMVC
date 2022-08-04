using DemoMVC.Domain.Abstract;
using DemoMVC.Domain.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Web.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController()
        {
            repository = new ProductRepository();
        }
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Products
                                            .Select(p => p.Category)
                                            .Distinct();
            return PartialView(categories);
        }
    }
}
