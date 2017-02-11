using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Models.Contracts
{
    public interface IProduct : IDbModel, INamable, IDescribable
    {
        string ModelNumber { get; set; }

        Guid CategoryId { get; set; }

        Guid BrandId { get; set; }

        decimal price { get; set; }

        bool isInPromotion { get; set; }

        decimal promoPrice { get; set; }

        ICollection<IPhoto> Photos { get; set; }

        ICollection<ISize> Sizes { get; set; }

    }
}
