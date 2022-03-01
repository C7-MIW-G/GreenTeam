using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class Garden
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for your garden.")]
        [StringLength(15)]
        [RegularExpression(@"[a-zA-Z0-9 \\'\\-]{1,15}", 
            ErrorMessage = "Please provide a name with the maximum length of 15 characters using only letters, digits" +
            " and the special characters single quote( ' ) and dash(-).")]
        public string Name { get; set; }

        [StringLength (35)]
        public string Location { get; set; }

        public byte[] GardenPhoto { get; set; }

        public ICollection<Patch> Patches { get; set; }
        public ICollection<GardenUser> GardenUsers { get; set; }
    
        
    
    }
}
