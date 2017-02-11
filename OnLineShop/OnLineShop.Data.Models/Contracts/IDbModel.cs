using System;

namespace OnLineShop.Data.Models.Contracts
{
    public interface IDbModel
    {
         Guid Id { get; }

        bool IsDeleted { get; set; }
    }
}
