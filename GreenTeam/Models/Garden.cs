namespace GreenTeam.Models
{
    public class Garden
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Patch> Patches { get; set; }
        public ICollection<GardenUser> GardenUsers { get; set; }
    }
}
