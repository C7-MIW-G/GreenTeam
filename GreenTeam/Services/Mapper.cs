using GreenTeam.ViewModels;
using GreenTeam.Models;

namespace GreenTeam.Services
{
    public class Mapper
    {
        
        public GardenVM ToVM(Garden gardenModel)
        {


            GardenVM vm = new GardenVM()

            {
                Id = gardenModel.Id,
                Name = gardenModel.Name,
                Location = gardenModel.Location,
               // List <Patch> Patches = Patches1.Cast<Garden>.ToList()

        };

            return vm;

        }
    }    
}