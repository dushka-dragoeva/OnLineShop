using OnLineShop.Data.Models;
using System.Linq;

namespace OnLineShop.MVP.Categories.Admin
{
    public class CategoriesAdminViewModel
    {
        public IQueryable<Category> Categories { get; set; }
    }
}
