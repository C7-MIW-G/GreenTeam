using Microsoft.AspNetCore.Mvc;
using GreenTeam.Models;
using GreenTeam.ViewModels;

namespace GreenTeam.ViewModelMapper

{
    public class Mapper
    {

        public static GardenViewModel CreateGardenViewModel(Garden garden, List<Patch> patches)
        {
            GardenViewModel gardenViewModel = new GardenViewModel();
         
            gardenViewModel.Garden = garden;
            gardenViewModel.Patches = patches;
        

            return gardenViewModel;
        }
    }
}
