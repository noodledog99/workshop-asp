using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace workshop_asp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FullName", $"{this.FirstName} {this.LastName}"));;
            userIdentity.AddClaim(new Claim("Role", this.Role.ToString()));
           

            return userIdentity;
        }


        [Required]
        [StringLength(20, ErrorMessage = "first name at least 2 charactor", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "last name at least 2 charactor", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "address at least 2 charactor", MinimumLength = 2)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "city name at least 2 charactor", MinimumLength = 2)]
        [Display(Name = "City")]
        public string City { get; set; }
        public int Role { get; set; }

    }





    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}
