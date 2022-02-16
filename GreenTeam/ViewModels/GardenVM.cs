using GreenTeam.Models;

namespace GreenTeam.ViewModels
{
        public class GardenVM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<PatchVM> Patches { get; set; }
        //public List<AppUserVM> Users { get; set; }

        //public list of patch viewmodels
        //public list of appUser Viewmodels

    }
}
