using OnLineShop.Data.Models;
using OnLineShop.Data.Services.Contracts;
using System.Linq;
using System;
using System.Data.Entity;

namespace OnLineShop.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IOnLineShopDbContext Context;

        public ProductService(IOnLineShopDbContext context)
        {
            this.Context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return this.Context.Products.Where(c => c.IsDeleted == false);
        }

        public Product GetById(int? id)
        {
            return this.Context.Products.Find(id);
        }

        public int Insert(Product product)
        {
            this.Context.Products.Add(product);
            return this.Context.SaveChanges();
        }

        public int Delete(int? id)
        {
            var entity = this.GetById(id);
            entity.IsDeleted = true;
            return this.Context.SaveChanges();
        }

        public int Update(Product product)
        {

            Product productToUpdate = this.GetById(product.Id);
            this.Context.Entry(productToUpdate).CurrentValues.SetValues(product);

            return this.Context.SaveChanges();
        }

        public IQueryable<Product> GetAllWithCategoryBrandPhotos()
        {
            return this.Context.Products
                .Where(c => c.IsDeleted == false)
                .Include(c => c.Category)
                .Include(c => c.Brand);
        }
    }
}
