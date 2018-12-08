using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITIMM.Models;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace ITIMM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .HasOne<Custodian>(au=>au.CustodianUser)
                .WithOne(c => c.IdentityUser)
                .HasForeignKey<Custodian>(c=>c.Id);
                
        }
        public DbSet<Custodian> custodians { get; set; }
        public DbSet<Category> categories  { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Comments> comments  { get; set; }
        public DbSet<Complaints> complaints  { get; set; }
    }
}
