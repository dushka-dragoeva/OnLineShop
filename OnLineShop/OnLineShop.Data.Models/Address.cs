using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnLineShop.Data.Models.Contracts;
namespace OnLineShop.Data.Models
{
    public class Address : IDbModel

    {
        public const int StreetMinLength = 2;
        public const int StreetMaxLength = 100;
        public ICollection<ContactInfo> contactInfo;

        public Address()
        {
            this.contactInfo = new HashSet<ContactInfo>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(StreetMinLength)]
        [MaxLength(StreetMaxLength)]
        [RegularExpression(Utils.Constants.EnBgSpaceMinus)]
        public string AddressLine { get; set; }

        public string PostCode { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        //public virtual ContactInfo ContactInfo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
