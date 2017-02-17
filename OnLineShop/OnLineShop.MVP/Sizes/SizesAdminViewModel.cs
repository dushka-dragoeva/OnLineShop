using System.Linq;

using OnLineShop.Data.Models;

namespace OnLineShop.MVP.Sizes
{
    public class SizesAdminViewModel
    {
        public IQueryable<Size> Sizes { get; set; }
    }
}
