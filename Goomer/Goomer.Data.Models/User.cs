using Goomer.Data.Models.BaseModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Goomer.Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Tire> tires;
        private ICollection<Rim> rims;
        private ICollection<RimWithTire> rimsWithTires;

        public User()
        {
            this.tires = new HashSet<Tire>();
            this.rims = new HashSet<Rim>();
            this.rimsWithTires = new HashSet<RimWithTire>();

        }
        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Rim> Rims
        {
            get { return this.rims; }
            set { this.rims = value; }
        }

        public virtual ICollection<Tire> Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }

        public virtual ICollection<RimWithTire> RimsWithTires
        {
            get { return this.rimsWithTires; }
            set { this.rimsWithTires = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void SetAdmin()
        {
            if (IsAdmin && !this.Roles.Any(x => x.RoleId == "1"))
            {
                this.Roles.Add(new IdentityUserRole { RoleId = "1", UserId = this.Id });
            }

            if (!IsAdmin && this.Roles.Any(x => x.RoleId == "1"))
            {
                var role = this.Roles.Where(x => x.RoleId == "1").FirstOrDefault();
                this.Roles.Remove(role);
            }
        }

    }
}