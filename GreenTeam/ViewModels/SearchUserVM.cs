using System.ComponentModel.DataAnnotations;

namespace GreenTeam.ViewModels
{
    public class SearchUserVM
    {
        [Display(Name = "Enter email"), Required]
        [EmailAddress]
        public string Email { get; set; }
        public int GardenId { get; set; }
        public string ConfirmationMessage = "";
    }
}
