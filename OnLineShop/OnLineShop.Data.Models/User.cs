using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace OnLineShop.Data.Models
{
    public class User : IdentityUser
    {
        [MinLength(Utils.Constants.NameMinLength)]
        [MaxLength(Utils.Constants.NameMaxLength)]
        [RegularExpression(Utils.Constants.EnBgSpaceMinus)]
        public string FirstName { get; set; }

        [MinLength(Utils.Constants.NameMinLength)]
        [MaxLength(Utils.Constants.NameMaxLength)]
        [RegularExpression(Utils.Constants.EnBgSpaceMinus)]
        public string LastName { get; set; }

        public DeliveryAddress Address { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        public virtual Order order { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
