using DemoMVC.Domain.Abstract;
using DemoMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext context;

        public ProductRepository()
        {
            context = new ProductContext();
            context.Database.EnsureCreated();
        }

        public IEnumerable<Product> Products {
            get { 
                return context.Products
                              .OrderByDescending(p => p.Name); 
            } 
        }
    }
}
