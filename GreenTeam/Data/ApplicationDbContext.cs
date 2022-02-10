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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GardenUsers>()

                .HasKey(c => new { c.GardenId, c.UserId })
                .HasName("PrimaryKey_GardenUserId");
        }


        public DbSet<Garden> Garden { get; set; }
        public DbSet<Patch> Patch { get; set; }
        public DbSet<GardenUsers> GardenUser { get; set;}


        


    }
}