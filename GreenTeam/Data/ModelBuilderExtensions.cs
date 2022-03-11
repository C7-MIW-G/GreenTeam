using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GreenTeam.Utils
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {     
            AppUser appUser1 = new AppUser()
            {
                Id = "f9f1d318-e966-4f44-925c-5b661f94ae98",
                UserName = "iris@greenteam.com",                
                Email = "iris@greenteam.com",
                NormalizedUserName = "iris@greenteam.com".ToUpper(),
                NormalizedEmail = "iris@greenteam.com".ToUpper(),            
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,
                FullName = "Iris Hagen",
            };

            AppUser appUser2 = new AppUser()
            {
                Id = "d9ef8fe1-a012-42b4-917d-ff4aa7af2c6d",
                UserName = "marcel@greenteam.com",
                Email = "marcel@greenteam.com",
                NormalizedUserName = "marcel@greenteam.com".ToUpper(),
                NormalizedEmail = "marcel@greenteam.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,
                FullName = "Marcel Klerken"
            };

            AppUser appUser3 = new AppUser()
            {
                Id = "bca6b676-85d9-4737-8dff-a21b1708e32e",
                UserName = "noa@greenteam.com",
                Email = "noa@greenteam.com",
                NormalizedUserName = "noa@greenteam.com".ToUpper(),
                NormalizedEmail = "noa@greenteam.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,
                FullName = "Noa Zeegers",
            };

            AppUser appUser4 = new AppUser()
            {
                Id = "d356bc6c-2f41-4a96-b500-359cd8fe008e",
                UserName = "sem@greenteam.com",
                Email = "sem@greenteam.com",
                NormalizedUserName = "sem@greenteam.com".ToUpper(),
                NormalizedEmail = "sem@greenteam.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed= true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,
                FullName = "Sem Peters",
            };

            AppUser appUser5 = new AppUser()
            {
                Id = "86d1b277-8b29-436a-b449-90320cd9779b",
                UserName = "roy@greenteam.com",
                Email = "roy@greenteam.com",
                NormalizedUserName = "roy@greenteam.com".ToUpper(),
                NormalizedEmail = "roy@greenteam.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,
                FullName = "Roy Hermans",
            };

            AppUser appUser6 = new AppUser()
            {
                Id = "20fc5ce4-8a75-4808-99f8-cb5c43ba6d72",
                UserName = "sylvia@greenteam.com",
                Email = "sylvia@greenteam.com",
                NormalizedUserName = "sylvia@greenteam.com".ToUpper(),
                NormalizedEmail = "sylvia@greenteam.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,            
                FullName = "Sylvia Albers",
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();

            appUser1.PasswordHash = ph.HashPassword(appUser1, "Test123!");
            appUser2.PasswordHash = ph.HashPassword(appUser2, "Test123!");
            appUser3.PasswordHash = ph.HashPassword(appUser3, "Test123!");
            appUser4.PasswordHash = ph.HashPassword(appUser4, "Test123!");
            appUser5.PasswordHash = ph.HashPassword(appUser5, "Test123!");
            appUser6.PasswordHash = ph.HashPassword(appUser6, "Test123!");

            modelBuilder.Entity<AppUser>().HasData(appUser1);
            modelBuilder.Entity<AppUser>().HasData(appUser2);
            modelBuilder.Entity<AppUser>().HasData(appUser3);
            modelBuilder.Entity<AppUser>().HasData(appUser4);
            modelBuilder.Entity<AppUser>().HasData(appUser5);
            modelBuilder.Entity<AppUser>().HasData(appUser6);
        }
    }
}
