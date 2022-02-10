using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class GardenUsers
    { 
        public string UserId { get; set; }
        public int GardenId { get; set; }
        public bool IsGardenManager { get; set; }
        public Garden Garden { get; set; }
    }
}
