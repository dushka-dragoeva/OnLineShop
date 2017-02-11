using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data
{
    public interface IOnLineShopDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Brand> Brands { get; set; }

        IDbSet<DeliveryAddress> DeliveryAddress { get; set; }

        IDbSet<Photo> Photos { get; set; }  // Could be only string

        IDbSet<Size> Sizes { get; set; }

        IDbSet<Town> Towns { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<CartItem> ShoppingCartItems { get; set; }

        IDbSet<OrderDetail> OrderDetail { get; set; }

        IDbSet<Order> Order { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
