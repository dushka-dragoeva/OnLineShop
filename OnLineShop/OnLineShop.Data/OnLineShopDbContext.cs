using System;
using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using OnLineShop.Data.Models;

namespace OnLineShop.Data
{
    public class OnLineShopDbContext : IdentityDbContext<User>, IOnLineShopDbContext
    {

        public OnLineShopDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Brand> Brands { get; set; }

        public IDbSet<DeliveryAddress> DeliveryAddress { get; set; }

        public IDbSet<Photo> Photos { get; set; }  // Could be only string

        public IDbSet<Size> Sizes { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<CartItem> ShoppingCartItems { get; set; }

        public IDbSet<OrderDetail> OrderDetail { get; set; }

        public IDbSet<Order> Order{ get; set; }

        public static OnLineShopDbContext Create()
        {
            return new OnLineShopDbContext();
        }
    }
}

