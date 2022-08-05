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

        public Product SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product? selectedProduct = context.Products
                                            .Find(product.ProductId);
                if(selectedProduct != null)
                {
                    selectedProduct.Name = product.Name;
                    selectedProduct.Description = product.Description;
                    selectedProduct.Price = product.Price;
                    selectedProduct.Category = product.Category;
                }
            }
            context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int productId)
        {
            var product = context.Products.Find(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product ?? new Product();
        }
    }
}
