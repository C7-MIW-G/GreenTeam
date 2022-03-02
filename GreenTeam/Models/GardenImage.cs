using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTeam.Models
{
    public class GardenImage
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string FileType { get; set; }

        public byte[] Content { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
