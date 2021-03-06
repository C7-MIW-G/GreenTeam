using GreenTeam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GreenTeam.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GardenUser>()
                .HasKey(c => new { c.GardenId, c.UserId })
                .HasName("PrimaryKey_GardenUserId");                   
        }

        public DbSet<Garden> Garden { get; set; }
        public DbSet<Patch> Patch { get; set; }
        public DbSet<GardenUser> GardenUser { get; set; }
        public DbSet<PatchTask> PatchTask { get; set; }
        public DbSet<Image> Image { get; set; }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
    }
}