using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class Patch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for your patch.")]
        [StringLength(20)]
        [RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,20}",
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe( ' ).")]
        public string PatchName { get; set; }
        
        [StringLength(20)]
        [RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,20}", 
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe( ' ).")]
        public string Crop { get; set; }
        
        public int GardenId { get; set; }
        [Required(ErrorMessage = "Please enter a name for your patch."),
            StringLength(20), RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,20}",
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe(').")]
        
        public string PatchName { get; set; }
       
        public ICollection<PatchTask> PatchTasks { get; set; }
    }
}
