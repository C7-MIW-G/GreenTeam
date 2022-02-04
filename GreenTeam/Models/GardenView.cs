namespace GreenTeam.Models
{   
    public class GardenView
    {
        public int GardenViewId { get; set; }
        public Garden Garden { get; set; }
        public List<Patch> Patches { get; set; }
    }
}
