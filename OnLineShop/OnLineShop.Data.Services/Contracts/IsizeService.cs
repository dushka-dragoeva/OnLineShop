using OnLineShop.Data.Models;
using System.Linq;

namespace OnLineShop.Data.Services.Contracts
{
    public interface ISizeService
    {
        IQueryable<Size> GetAll();

        Size GetById(int? id);

        void Update(Size size);

        void Delete(int? id);

        int Insert(Size size);
    }
}
