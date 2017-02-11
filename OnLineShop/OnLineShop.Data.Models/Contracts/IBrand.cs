using System.Collections.Generic;

namespace OnLineShop.Data.Models.Contracts
{
    public interface IBrand : IDbModel, INamable, IContainProducts, IDescribable
    {
    }
}
