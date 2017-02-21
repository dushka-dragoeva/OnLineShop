using OnLineShop.Data.Models;

using System.Linq;

namespace OnLineShop.MVP.Categories.Client
{
    public class CategoriesViewModel
    {
        public IQueryable<Category> Categories { get; set; }

        public Category Category { get; set; }
    }
}
