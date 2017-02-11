using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OnLineShop.Data.Models.Utils;
using OnLineShop.Data.Models.Contracts;

namespace OnLineShop.Data.Models
{
    public class Brand : IBrand, IDbModel, INamable
    {
        private ICollection<IProduct> products;

        public Brand()
        {
            this.Products = new HashSet<IProduct>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(20)]
        [RegularExpression(Constants.EnBgDigitSpaceMinus)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MinLength(Constants.DescriptionMinLength)]
        [MaxLength(Utils.Constants.DescriptionMaxLength)]
        [RegularExpression(Constants.DescriptionRegex)]
        public string Description { get; set; }

        public virtual ICollection<IProduct> Products
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
