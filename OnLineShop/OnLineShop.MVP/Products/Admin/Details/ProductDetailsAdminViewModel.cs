using OnLineShop.Data.Models;
using System.Linq;

namespace OnLineShop.MVP.Products.Admin.Details
{
    public class ProductDetailsAdminViewModel
    {
        public IQueryable<Product> Products { get; set; }

        public Product Product { get; set; }

    }
}
