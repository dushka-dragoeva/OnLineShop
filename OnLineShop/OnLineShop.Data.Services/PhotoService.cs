
using OnLineShop.Data.Services.Contracts;
using OnLineShop.Data.Models;

namespace OnLineShop.Data.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IOnLineShopDbContext Context;

        public PhotoService(IOnLineShopDbContext context)
        {
            this.Context = context;
        }

        public Photo GetById(int? id)
        {
            return id.HasValue? this.Context.Photos.Find(id): null;
        }

        public int Insert(Photo photo)
        {
            this.Context.Photos.Add(photo);
            return this.Context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = this.GetById(id);
            entity.IsDeleted = true;
            return this.Context.SaveChanges();
        }

        public int Update(Photo photo)
        {
            Photo photoToUpdate = this.GetById(photo.Id);
            this.Context.Entry(photoToUpdate).CurrentValues.SetValues(photo);

            return this.Context.SaveChanges();
        }
    }
}