using OnLineShop.Data.Models;
using System.Linq;

namespace OnLineShop.MVP.Products.Client
{
    public class ProductsViewModel
    {
        public IQueryable<Product> Products { get; set; }
    }
}
