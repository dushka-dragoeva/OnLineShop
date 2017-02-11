using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OnLineShop.Data.Models.Contracts;
using OnLineShop.Data.Models.Utils;

namespace OnLineShop.Data.Models
{
    public class Size: ISize , IDbModel,  IContainProducts
    {
        private ICollection<Product> products;

        public Size()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxValue)]
        [RegularExpression(Constants.EnBgDigitSpaceMinus)]
        public string Value { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
