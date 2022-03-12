using System.ComponentModel.DataAnnotations;

namespace GreenTeam.ViewModels
{
    public class PatchTaskVM
    {
        public int Id { get; set; }
        
        public int PatchId { get; set; }

        [Required(ErrorMessage = "Please enter a taskname.")]
        [StringLength(20)]
        [RegularExpression(@"[a-zA-Z0-9 äëïöü'-]{1,20}", 
            ErrorMessage = "Allowed characters are letters, digits, dash(-) and apostrophe( ' ).")]
        [Display(Name = "Task")]
        public string TaskName { get; set; }

        [StringLength(1024)]
        [Display(Name = "Description")]
        public string TaskDescription { get; set; }
    }
}
