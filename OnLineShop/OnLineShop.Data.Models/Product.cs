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
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        [RegularExpression(Constants.EnBgDigitSpaceMinus)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MinLength(Constants.DescriptionMinLength)]
        [MaxLength(Constants.DescriptionMaxLength)]
        [RegularExpression(Constants.DescriptionRegex)]
        public string Description { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        [RegularExpression(Constants.DescriptionRegex)]
        public string ModelNumber { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

      //  public virtual CartItem CartItem { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public decimal Price { get; set; }

        public bool IsInPromotion { get; set; }

        [Range(int.MinValue, int.MaxValue)]
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
