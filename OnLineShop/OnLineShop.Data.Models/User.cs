using System.Collections.Generic;

using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineShop.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Order> orders;
        private ICollection<Product> favorites;
        private ICollection<ContactInfo> contactInfos;

        public User()
        {
            this.orders = new HashSet<Order>();
            this.favorites = new HashSet<Product>();
            this.contactInfos = new HashSet<ContactInfo>();
        }

       // [ForeignKey("ContactInfo")]
      //  public int ContactInfoId { get; set; }

  
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders
        {
            get
            {
                return this.orders;
            }

            set
            {
                this.orders = value;
            }
        }

        public virtual ICollection<Product> Favorites
        {
            get
            {
                return this.favorites;
            }

            set
            {
                this.favorites = value;
            }
        }

        public virtual ICollection<ContactInfo> ContactInfo
        {
            get
            {
                return this.contactInfos;
            }

            set
            {
                this.contactInfos = value;
            }
        }

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
