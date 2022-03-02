using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTeam.Models
{
    public class PatchTask
    {
        public int Id { get; set; }
        public Patch Patch { get; set; }
        public int PatchId { get; set; }

        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

    }
}
