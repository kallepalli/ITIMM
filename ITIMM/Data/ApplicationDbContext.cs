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
                .WithOne(c => c.IdentityUser);
                
        }

    }
}
