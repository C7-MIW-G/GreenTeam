using GreenTeam.Implementations;
using GreenTeam.Utils;
using GreenTeam.Data;
using GreenTeam.Models;

namespace GreenTeam.Services
{
    public class ImageService : IImageService
    {
        private ApplicationDbContext context;

        public ImageService(ApplicationDbContext context)
        {
            this.context = context;
        }
               
        public async Task<int> AddImage(GardenImage gardenImage)
        {
            context.Add(gardenImage);
            await context.SaveChangesAsync();
            int imageId = gardenImage.Id;
            return imageId;
        }
    }
}
