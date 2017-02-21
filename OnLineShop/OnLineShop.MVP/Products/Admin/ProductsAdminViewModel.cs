using OnLineShop.Data.Models;
using System.Linq;

namespace OnLineShop.MVP.Products.Admin
{
    public class ProductsAdminViewModel
    {
        public IQueryable<Product> Products { get; set; }
    }
}
