using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OnLineShop.Data.Models.Utils;
using OnLineShop.Data.Models.Contracts;

namespace OnLineShop.Data.Models
{
    public class Product : IDbModel, INamable, IDescribable
    {
        public const int NumberOfPictures = 3;
        public const int UrlLengthMinLength = 6;
        public const int UrlLengthMaxValue = 300;

        private ICollection<Size> sizes;
        private ICollection<Photo> photos;
        private ICollection<Like> likes;
        private ICollection<User> users;

        public Product()
        {
            this.sizes = new HashSet<Size>();
            this.photos = new HashSet<Photo>();
            this.likes = new HashSet<Like>();
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength, ErrorMessage = Constants.ShortNameError)]
        [MaxLength(Constants.NameMaxLength, ErrorMessage = Constants.LongNameError)]
        [RegularExpression(Constants.EnBgDigitSpaceMinus, ErrorMessage = Constants.NotAllowedSymbolsError)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MinLength(Constants.DescriptionMinLength, ErrorMessage = Constants.ShortDescriptionError)]
        [MaxLength(Constants.DescriptionMaxLength, ErrorMessage = Constants.LongDescriptionError)]
        [RegularExpression(Constants.DescriptionRegex, ErrorMessage = Constants.NotAllowedSymbolsError)]
        public string Description { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength, ErrorMessage = Constants.ShortNameError)]
        [MaxLength(Constants.NameMaxLength, ErrorMessage = Constants.LongNameError)]
        [RegularExpression(Constants.DescriptionRegex, ErrorMessage = Constants.NotAllowedSymbolsError)]
        public string ModelNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Quantity; Range: 0, 2 147 483 647")]
        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        //  public virtual CartItem CartItem { get; set; }

        [MinLength(UrlLengthMinLength, ErrorMessage = Constants.ShortUrlError)]
        [MaxLength(UrlLengthMaxValue, ErrorMessage = Constants.LongUrlError)]
        public string PictureUrl { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Invalid Price; Maximum Two Decimal Points")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Price; Range:0, 9999999999999999.99 ")]
        public decimal Price { get; set; }

        public bool IsInPromotion { get; set; }

        // [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Invalid Promo Price; Maximum Two Decimal Points")]
        //[Range(0, 9999999999999999.99, ErrorMessage = "Invalid Promo Price; Range:0, 9999999999999999.99 ")]
        public decimal PromoPrice { get; set; }

        public virtual ICollection<Photo> Photos
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

        public virtual ICollection<Size> Sizes
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

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }

            set
            {
                this.likes = value;
            }
        }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
