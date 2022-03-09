using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class Garden
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for your garden."),
            StringLength(20), RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,20}",
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe(').")]
        public string Name { get; set; }

        [StringLength(35), RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,35}",
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe(').")]
        public string Location { get; set; }

        public ICollection<Patch> Patches { get; set; }

        public ICollection<GardenUser> GardenUsers { get; set; }

        public GardenImage GardenImage { get; set; }

        public int? GardenImageId { get; set; }
    }
}
