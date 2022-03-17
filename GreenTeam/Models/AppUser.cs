using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Models
{
    public class AppUser : IdentityUser, IComparable<AppUser>
    {
        public string FullName { get; set; }

        public int CompareTo(AppUser other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.UserName.CompareTo(other.UserName);
            }
        }
    }
}
