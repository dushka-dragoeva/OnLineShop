using System.Collections.Generic;

namespace OnLineShop.Data.Models.Contracts
{
    public interface ICategory : IDbModel, INamable, IContainProducts
    {
        ICollection<ICategory> SubCategories { get; set; }
    }
}
