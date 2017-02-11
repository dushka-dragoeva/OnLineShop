using OnLineShop.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Data.Models
{
    public class CartItem : IDbModel
    {
        [Key]
        public Guid Id { get; set; }  //or string

        /*The CartId property specifies the ID of the user that is associated with the item to purchase.
         * You'll add code to create this user ID when the user accesses the shopping cart. 
         * This ID will also be stored as an ASP.NET Session variable.
       */
        public Guid CartId { get; set; }   //  or string

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public bool IsDeleted { get; set; }
    }
}
