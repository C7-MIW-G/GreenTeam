using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTeam.Models
{
    public class PatchTask
    {
        public int Id { get; set; }
        public Patch Patch { get; set; }
        public AppUser AppUser { get; set; }
        [Required]
        public string TaskDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDone { get; set; }

    }
}
