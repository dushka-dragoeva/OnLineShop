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

        void UpdateName(int? id, string name);

        void Delete(int? id);

        Category Create(string name);
    }
}
