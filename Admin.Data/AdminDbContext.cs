using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Model.Models;
using static Admin.Data.AdminDbContext;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Admin.Data.Identity;

namespace Admin.Data
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)

        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }
    public class AdminDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public AdminDbContext() : base("AdminConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

      
        //public DbSet<Menu> Menus { set; get; }
        //public DbSet<MenuGroup> MenuGroups { set; get; }
        //public DbSet<Order> Orders { set; get; }
        //public DbSet<OrderDetail> OrderDetails { set; get; }      
        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductRange> ProductRanges { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }

        //public DbSet<Tag> Tags { set; get; }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }

        public static AdminDbContext Create()
        {
            return new AdminDbContext();
        }
        public class CustomUserRole : IdentityUserRole<int> { }
        public class CustomUserClaim : IdentityUserClaim<int> { }
        public class CustomUserLogin : IdentityUserLogin<int> { }

        public class CustomRole : IdentityRole<int, CustomUserRole>
        {
            public CustomRole() { }
            public CustomRole(string name) { Name = name; }
        }

        public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
            CustomUserLogin, CustomUserRole, CustomUserClaim>
        {
            public CustomUserStore(AdminDbContext context)
                : base(context)
            {
            }
        }

        public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
        {
            public CustomRoleStore(AdminDbContext context)
                : base(context)
            {
            }
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<CustomUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<CustomUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<CustomRole>().ToTable("ApplicationRoles");
            builder.Entity<CustomUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");

        }

        
    }
}
