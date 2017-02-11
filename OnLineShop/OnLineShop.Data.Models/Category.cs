using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OnLineShop.Data.Models.Contracts;
using OnLineShop.Data.Models.Utils;

namespace OnLineShop.Data.Models
{
    public class Category: ICategory, IDbModel, INamable, IContainProducts
    {
        private ICollection<IProduct> products;
        private ICollection<ICategory> subCategories;

        public Category()
        {
            this.Products = new HashSet<IProduct>();
            this.SubCategories = new HashSet<ICategory>();
        }

        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
      
        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(20)]
        [RegularExpression(Constants.EnBgDigitSpaceMinus)]
        public string Name { get; set; }

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

        public virtual ICollection<ICategory> SubCategories
        {
            get
            {
                return this.subCategories;
            }

            set
            {
                this.subCategories = value;
            }
        }
    }
}
