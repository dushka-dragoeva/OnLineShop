using OnLineShop.Data.Models;
using OnLineShop.Data.Services.Contracts;
using System.Linq;

namespace OnLineShop.Data.Services
{
    public class BrandService : IBrandService
    {
        private readonly IOnLineShopDbContext Context;

        public BrandService(IOnLineShopDbContext context)
        {
            this.Context = context;
        }

        public int Insert(Brand Brand)
        {
            this.Context.Brands.Add(Brand);
            return this.Context.SaveChanges();
        }

        public int Delete(int? id)
        {
            var entity = this.GetById(id);
            entity.IsDeleted = true;
            return this.Context.SaveChanges();
        }

        public IQueryable<Brand> GetAll()
        {
            return this.Context.Brands.Where(c => c.IsDeleted == false);
        }

        public Brand GetById(int? id)
        {
            return id.HasValue ? this.Context.Brands.Find(id) : null;
        }

        public Brand GetByName(string name)
        {
            return this.Context.Brands.Find(name);
        }

        public int Update(Brand Brand)
        {

            Brand BrandToUpdate = this.Context.Brands.Find(Brand.Id);
            this.Context.Entry(BrandToUpdate).CurrentValues.SetValues(Brand);

            return this.Context.SaveChanges();
        }
    }
}
