using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTeam.Models
{
    [NotMapped]
    public class ApplicationRole
    {
        public int Id { get; set; }

        public string RoleName { get; set;}
    }
}
