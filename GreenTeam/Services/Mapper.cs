﻿using Microsoft.AspNetCore.Mvc;
using GreenTeam.ViewModels;
using GreenTeam.Models;

namespace GreenTeam.Services
{
    public static class Mapper
    {
        public static GardenView createGardenView(Garden garden, List<Patch> patches)
        {
            GardenView gardenView = new GardenView();
            gardenView.Garden = garden;
            gardenView.Patches = patches;

            return gardenView;
            
        
        }



    }
}