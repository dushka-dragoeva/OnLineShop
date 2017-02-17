using OnLineShop.Data.Models;
using System.Linq;

namespace OnLineShop.MVP.Brands.Admin
{
    public class BrandsAdminViewModel
    {
        public IQueryable<Brand> Brands { get; set; }
    }
}
