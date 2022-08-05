using DemoMVC.Domain.Abstract;
using DemoMVC.Domain.Concrete;
using DemoMVC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Web.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        
        public AdminController()
        {
            repository = new ProductRepository();
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View(repository.Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
            }
            TempData["message"] = $"Created new product, You edit product here";
            TempData["productId"] = product.ProductId;
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Route("Edit/{productId:int}")]
        public IActionResult Edit(int productId)
        {
            Product? product = repository.Products
                                .FirstOrDefault(p => p.ProductId == productId);
            if (product == null) 
                return RedirectToAction("Index", "Admin");
            return View(product);
        }

        [HttpPost]
        [Route("Edit/{productId:int}")]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
            }
            TempData["message"] = $"Updated product id {product.ProductId}";
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Route("Delete/{productId:int}")]
        public IActionResult Delete(int productId)
        {
            repository.DeleteProduct(productId);
            TempData["message"] = $"Deleted product id {productId} already";
            return RedirectToAction("Index", "Admin");
        }
    }
}
