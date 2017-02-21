using System;

namespace OnLineShop.MVP.Products.Admin
{
    public class ProductsAdminEventArgs: EventArgs
    {
        public ProductsAdminEventArgs(int id)

        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
