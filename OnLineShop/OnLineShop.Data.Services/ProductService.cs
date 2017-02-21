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

        public IQueryable<Product> GetAllWithCategoryBrand()
        {
            var pr= Context.Products
                .Where(p => p.IsDeleted == false)
                 .Include(p => p.Brand)
                 .Include(p => p.Category);

            return this.Context.Products
                .Where(p => p.IsDeleted == false)
                 .Include(p => p.Brand)
                 .Include(p => p.Category);
        }


        public IQueryable<Product> GetAllByCategory(int categoryId)
        {
            return this.Context.Products
                .Where(p => p.IsDeleted == false)
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Brand);
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
    }
}
