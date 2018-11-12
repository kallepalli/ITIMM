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
        public DbSet<IdentityUser> ApplicationUsers { get; set; }

    }
}
