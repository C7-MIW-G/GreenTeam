using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class UserDetails
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public ICollection<GardenUser> GardenUsers { get; set;}

    }
}
