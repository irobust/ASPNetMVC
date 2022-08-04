using DemoMVC.Web.Interfaces;

namespace DemoMVC.Web.Models
{
    public partial class InMemoryProducts : IInmemoryProducts
    {
        private Product[] products;
        public InMemoryProducts()
        {
            this.products = new Product[]{
                new Product(){ ProductId = 1, Name="product A", price = 100M},
                new Product(){ ProductId = 2, Name="product B", price = 200M},
                new Product(){ ProductId = 3, Name="product C", price = 300M}
            };
        }

        public Product[] GetAll()
        {
            return this.products;
        }

    }
}
