﻿namespace GreenTeam.ViewModels
{
        public class GardenVM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public byte[] GardenPhoto { get; set; }

        public List<PatchVM> Patches { get; set; }
        public List<AppUserVM> Users { get; set; }
    }
}
