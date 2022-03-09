using GreenTeam.Models;
using System.ComponentModel.DataAnnotations;

namespace GreenTeam.ViewModels
{
        public class GardenVM
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for your garden.")]
        [StringLength(20)]
        [RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,20}", 
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe( ' ).")]
        public string Name { get; set; }

        [StringLength(35)]
        [RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,35}", 
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe( ' ).")]
        public string Location { get; set; }
        
        public int? ImageId { get; set; }

        public List<PatchVM> Patches { get; set; }
        
        public List<AppUserVM> Users { get; set; }
        
        public Image Image { get; set; }
    }
}
