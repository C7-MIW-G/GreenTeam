using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTeam.Models
{
    public class GardenUser
    {   

        public string UserId { get; set; }
        public AppUser User  { get; set; }

        public bool IsGardenManager { get; set; }

        public int GardenId { get; set; }
        public Garden Garden { get; set; }
    }
}
