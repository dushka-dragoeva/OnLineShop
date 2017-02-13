using System;

namespace OnLineShop.Data.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IOnLineShopDbContext dbContext;

        public UnitOfWork(IOnLineShopDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            this.dbContext = dbContext;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
