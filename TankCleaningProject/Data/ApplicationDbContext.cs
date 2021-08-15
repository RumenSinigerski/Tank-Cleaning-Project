using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TankCleaningProject.Data.Models;

namespace TankCleaningProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Wash> Washes { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Wash>()
                .HasOne(w => w.Company)
                .WithMany(w => w.Washes)
                .HasForeignKey(w => w.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Wash>()
                .HasOne(w => w.ProductType)
                .WithMany(d => d.Washes)
                .HasForeignKey(w => w.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Company>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Company>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
