using DemoMVC.Domain;
using DemoMVC.Domain.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Web.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private ProductRepository repository;
        public NavViewComponent()
        {
            repository = new ProductRepository();
        }
        public IViewComponentResult Invoke(Category currentCategory)
        {
            IEnumerable<Category> categories = repository.Products
                                            .Select(p => p.Category)
                                            .Distinct();
            ViewBag.CurrentCategory = currentCategory;
            return View(categories);
        }
    }
}
