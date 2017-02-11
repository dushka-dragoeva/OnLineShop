using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnLineShop.Data.Models.Contracts;

namespace OnLineShop.Data.Models
{
    public class Town : IDbModel, INamable
    {
        public Guid Id { get; set; }
        
        public bool IsDeleted { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Utils.Constants.NameMinLength)]
        [MaxLength(Utils.Constants.NameMinLength)]
        [RegularExpression(Utils.Constants.EnBgDigitSpaceMinus)]
        public string Name { get; set; }
       
    }
}
