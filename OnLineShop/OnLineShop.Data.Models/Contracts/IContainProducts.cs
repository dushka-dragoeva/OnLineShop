using System.Collections.Generic;

namespace OnLineShop.Data.Models.Contracts
{
    public interface IContainProducts
    {
        ICollection<IProduct> Products { get; set; }
    }
}
