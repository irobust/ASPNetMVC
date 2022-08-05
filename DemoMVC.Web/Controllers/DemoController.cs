using Microsoft.AspNetCore.Mvc;
using DemoMVC.Web.Models;
using DemoMVC.Web.Interfaces;
using DemoMVC.Domain.Concrete;
using DemoMVC.Domain.Abstract;

namespace DemoMVC.Web.Controllers

{
    [Route("Demo")]
    [Route("/")]
    public class DemoController : Controller
    {
        private ProductRepository repository;
        private int PageSize = 1;

        public DemoController()
        {
            repository = new ProductRepository();
        }

        [Route("GetProducts/{category?}")]
        public IActionResult GetProducts(Domain.Category? category =null, int page=1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductId)
                                     .Where(p => category == null || p.Category == category)
                                     .Skip((page - 1) * PageSize)
                                     .Take(PageSize).ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = repository.Products
                                           .Where(p => category == null || p.Category == category)
                                           .Count()
                },
                CurrentCategory = category ?? Domain.Category.Food
            };
            return View(model);
        }

        public IActionResult Index()
        {
            IInmemoryProducts products = new InMemoryProducts();
            var total = products.TotalPrice();
            ViewData["total"] = total;
            ViewBag.Total = total;
            return View(products.GetAll());
        }


    }
}
