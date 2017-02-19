using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Services.Contracts
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();

        IQueryable<Product> GetAllWithCategoryBrandPhotos();

        Product GetById(int? id);

        int Update(Product product);

        int Delete(int? id);

        int Insert(Product product);
    }
}
