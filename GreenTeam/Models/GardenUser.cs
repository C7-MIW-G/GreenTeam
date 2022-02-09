using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GreenTeam.Models
{
    [Table(name: "GardenUsers")]
    public class GardenUser 
    {
        [Key]
        public int Id { get; set; }

        public IdentityUser IdentityUser { get; set; }
        public Garden Garden { get; set; }
    }
}
