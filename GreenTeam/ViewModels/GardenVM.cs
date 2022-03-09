using GreenTeam.Models;

namespace GreenTeam.ViewModels
{
        public class GardenVM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? ImageId { get; set; }

        public List<PatchVM> Patches { get; set; }
        public List<AppUserVM> Users { get; set; }
        public Image Image { get; set; }
    }
}
