﻿namespace GreenTeam.Models
{
    public class Patch
    {
        public int Id { get; set; }
        public string PatchName { get; set; }

        public string Crop { get; set; }

        public Garden Garden { get; set; }

        public int GardenId { get; set; }

    }
}
