using System.ComponentModel.DataAnnotations;


namespace GreenTeam.ViewModels
{
    public class AppUserVM
    {
        public string UserName { get; set; }
        [Display(Name = "User's email adress")]
        public string UserEmail { get; set; }
        public bool IsGardenManager { get; set; }
    }
}
