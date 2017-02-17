using System.Linq;

using OnLineShop.Data.Models;

namespace OnLineShop.MVP.Categories
{
    public class CategoriesViewModel
    {
        public IQueryable<Category> Categories { get; set; }

        public Category Category { get; set; }
    }
}
