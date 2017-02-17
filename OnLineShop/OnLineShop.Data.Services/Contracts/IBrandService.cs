using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Services.Contracts
{
    public interface IBrandService
    {
        IQueryable<Brand> GetAll();

        Brand GetById(int? id);

        Brand GetByName(string name);

        void Update(Brand Brand);

        void Delete(int? id);

        int Insert(Brand Brand);
    }
}
