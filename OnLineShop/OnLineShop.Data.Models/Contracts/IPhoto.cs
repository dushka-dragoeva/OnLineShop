using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Models.Contracts
{
    public interface IPhoto : IDbModel
    {
        string PictureBase64 { get; set; }

        string MimeType { get; set; }

        int ProductId { get; set; }
    }
}
