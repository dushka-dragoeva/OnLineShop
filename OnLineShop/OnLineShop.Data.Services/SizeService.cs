﻿using OnLineShop.Data.Models;
using OnLineShop.Data.Services.Contracts;
using System.Linq;

namespace OnLineShop.Data.Services
{
    public class SizeService:ISizeService

    {
        private readonly IOnLineShopDbContext Context;

        public SizeService(IOnLineShopDbContext context)
        {
            this.Context = context;
        }

        public int Insert(Size size)
        {
            this.Context.Sizes.Add(size);
            return this.Context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = this.GetById(id);
            entity.IsDeleted = true;
            this.Context.SaveChanges();
        }

        public IQueryable<Size> GetAll()
        {
            return this.Context.Sizes.Where(c => c.IsDeleted == false);
        }

        public Size GetById(int? id)
        {
            return this.Context.Sizes.Find(id);
        }

        public void Update(Size Size)
        {
            Size SizeToUpdate = this.Context.Sizes.Find(Size.Id);
            this.Context.Entry(SizeToUpdate).CurrentValues.SetValues(Size);

            this.Context.SaveChanges();
        }
    }
}
