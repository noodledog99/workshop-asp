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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public class ApplicationRole : IdentityRole
        {
            public ApplicationRole() : base() { }
            public ApplicationRole(string roleName) : base(roleName) { }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("users").Property(ur => ur.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityRole>().ToTable("roles").Property(ur => ur.Id).HasColumnName("RoleId"); ;
            modelBuilder.Entity<IdentityUserRole>().ToTable("userroles").HasKey(k => new { k.RoleId, k.UserId });
            modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogins");
        }


    }
}
