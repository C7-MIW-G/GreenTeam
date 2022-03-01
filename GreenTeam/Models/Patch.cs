using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class Patch
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Crop { get; set; }
        public int GardenId { get; set; }
        [Required(ErrorMessage = "Please enter a patchname.")]
        [StringLength(15)]
        [RegularExpression(@"[a-zA-Z0-9 \\'\\-]{1,20}",
            ErrorMessage = "Please provide a patchname with the maximum length of 20 characters using only letters, digits" +
            " and the special characters single quote( ' ) and dash(-).")]
        public string PatchName { get; set; }
    }
}
