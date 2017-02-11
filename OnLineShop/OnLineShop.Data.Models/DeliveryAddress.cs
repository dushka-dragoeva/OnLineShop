using OnLineShop.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineShop.Data.Models
{
    public class DeliveryAddress : IDbModel

    {
        public const int StreetMinLength = 2;
        public const int StreetMaxLength = 100;

        public Guid Id { get; set; }

        [Required]
        [MinLength(StreetMinLength)]
        [MaxLength(StreetMaxLength)]
        [RegularExpression(Utils.Constants.EnBgSpaceMinus)]
        public string AddressLine { get; set; }

        [ForeignKey("Town")]
        public Guid TownId { get; set; }

        public virtual Town Town { get; set; }

        public bool IsDeleted { get; set; }

    }
}
