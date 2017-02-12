using OnLineShop.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Models
{
    public class Order:IDbModel
    {
        private ICollection<OrderDetail> orderDetails;

        public Order()
        {
            this.orderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenConfirmed { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenShipped { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenClosed { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails
        {
            get
            {
                return this.orderDetails;
            }
            set
            {
                this.orderDetails = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
