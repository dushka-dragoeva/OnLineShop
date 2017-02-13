using System;

namespace OnLineShop.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
