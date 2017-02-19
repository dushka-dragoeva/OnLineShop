using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Services
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        Category GetById(int? id);

        Category GetByName(string name);

        int Update(Category category);

        int Delete(int? id);

        int Insert(Category category);
    }
}
