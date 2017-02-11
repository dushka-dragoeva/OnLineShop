using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OnLineShop.Data.Models.Utils;
using OnLineShop.Data.Models.Contracts;

namespace OnLineShop.Data.Models
{
    public class Product : IProduct, IDbModel, INamable, IDescribable
    {
        public const int NumberOfPictures = 3;
                     
        private ICollection<ISize> sizes;
        private ICollection<IPhoto> photos;

        public Product()
        {
            this.Sizes = new HashSet<ISize>();
            this.Photos = new HashSet<IPhoto>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMinLength)]
        [RegularExpression(Constants.EnBgDigitSpaceMinus)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MinLength(Constants.DescriptionMinLength)]
        [MaxLength(Constants.DescriptionMaxLength)]
        [RegularExpression(Constants.DescriptionRegex)]
        public string Description { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMinLength)]
        [RegularExpression(Constants.DescriptionRegex)]
        public string ModelNumber { get; set; }

        [Required]
        [Range(int.MinValue,int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public decimal price { get; set; }

        public bool isInPromotion { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public decimal promoPrice { get; set; }

        public ICollection<IPhoto> Photos
        {
            get
            {
                return this.photos;
            }

            set
            {
                this.photos = value;
            }
        }

        public virtual ICollection<ISize> Sizes
        {
            get
            {
                return this.sizes;
            }

            set
            {
                this.sizes = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
