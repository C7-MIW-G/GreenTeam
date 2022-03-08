namespace GreenTeam.ViewModels
{
    public class PatchVM
    {
        public int Id { get; set; }
        public string PatchName { get; set; }
        public string Crop { get; set; }
        public List<PatchTaskVM> PatchTasks { get; set; }
        public int GardenId { get; set; }
        public bool isGardenManager { get; set; }
    }
}
