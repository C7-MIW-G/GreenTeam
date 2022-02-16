using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
