namespace workshop_asp.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using workshop_asp.Models;

    public partial class AppDb : IdentityDbContext<ApplicationUser>
    {
        public static AppDb Create()
        {
            return new AppDb();
        }

        public AppDb()
            : base("name=AppDb")
        {
        }

        public class ApplicationRole : IdentityRole
        {
            public ApplicationRole() : base() { }
            public ApplicationRole(string roleName) : base(roleName) { }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
