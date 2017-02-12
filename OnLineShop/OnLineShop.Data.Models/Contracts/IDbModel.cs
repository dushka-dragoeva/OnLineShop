using System;

namespace OnLineShop.Data.Models.Contracts
{
    public interface IDbModel
    {
         int Id { get; }

        bool IsDeleted { get; set; }
    }
}
