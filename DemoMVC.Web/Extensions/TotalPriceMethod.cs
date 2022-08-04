using DemoMVC.Web.Interfaces;
using DemoMVC.Web.Models;

namespace DemoMVC.Web.Extensions
{
    public static class TotalPriceMethod
    {
        public static decimal TotalPrice(this IInmemoryProducts products)
        {
            decimal total = 0;
            foreach (Product product in products.GetAll())
            {
                total += product?.price ?? 0M;
            }
            return total;
        }
    }
}
