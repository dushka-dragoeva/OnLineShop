using OnLineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Services.Contracts
{
    public interface IPhotoService
    {
        Photo GetById(int id);

        int Update(Photo photo);

        int Delete(int id);

        int Insert(Photo photo);
    }
}
