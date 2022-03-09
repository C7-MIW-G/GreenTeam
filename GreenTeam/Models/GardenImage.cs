using System.ComponentModel.DataAnnotations;

namespace GreenTeam.Models
{
    public class GardenImage
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string FileType { get; set; }

        public byte[] Content { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
