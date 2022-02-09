using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Models;


namespace GreenTeam.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Garden> Garden { get; set; }
        public DbSet<Patch> Patch { get; set; }
        public DbSet<GardenUser> GardenUser { get; set; }
    }
}