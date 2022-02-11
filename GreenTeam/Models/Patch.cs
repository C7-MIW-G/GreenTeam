using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class Patch
    {
        public int Id { get; set; }
        public string Crop { get; set; }
        public int GardenId { get; set; }
        [Required]
        public string PatchName { get; set; }
    }
}
