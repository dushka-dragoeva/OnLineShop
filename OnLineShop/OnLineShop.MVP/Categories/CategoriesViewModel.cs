using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnLineShop.Data.Models;

namespace OnLineShop.MVP.Categories
{
    public class CategoriesViewModel
    {
        public IQueryable<Category> Categories { get; set; }
    }
}
