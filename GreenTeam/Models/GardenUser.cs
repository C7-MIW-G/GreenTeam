using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Models
{
    public class GardenUser 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public IdentityUser IdentityUser { get; set; }
        [Required]
        public Garden Garden { get; set; }
        [Required]
        public bool IsManager { get; set; }
        [Required]
        public bool IsMember { get; set; }
    }
}
