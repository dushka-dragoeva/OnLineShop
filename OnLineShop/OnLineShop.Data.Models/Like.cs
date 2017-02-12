using OnLineShop.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Models
{
    public class Like :IDbModel
    {
        public int Id { get; set; }

        public bool Value { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public bool IsDeleted { get; set; }

    }
}
