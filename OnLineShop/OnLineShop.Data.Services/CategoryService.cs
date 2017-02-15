using OnLineShop.Data.Models;
using OnLineShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Services
{
  public  class CategoryService: ICategoryService
    {
        private readonly IOnLineShopDbContext Context;

        public CategoryService(IOnLineShopDbContext context) 
        {
            this.Context = context;
        }

        public Category Create(string name)
        {
            var category = new Category() { Name = name };

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
            return category;
        }

        public void Delete(int? id)
        {
            var entity = this.GetById(id);
            entity.IsDeleted = true;
            this.Context.SaveChanges();
        }

        public IQueryable<Category> GetAll()
        {
            return this.Context.Categories.Where(c=>c.IsDeleted==false);
        }

        public Category GetById(int? id)
        {
            return this.Context.Categories.Find(id);
        }

        public Category GetByName(string name)
        {
            return this.Context.Categories.Find(name);
        }

        public void UpdateName(int? id, string newName)
        {

            Category categoryToUpdate = this.Context.Categories.Find(id);
            categoryToUpdate.Name = newName;
            this.Context.SaveChanges();
        }
    }
}

