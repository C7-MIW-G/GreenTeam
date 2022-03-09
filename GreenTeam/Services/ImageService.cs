using GreenTeam.Data;
using GreenTeam.Implementations;
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
               
        public async Task<int> AddImage(Image image)
        {
            context.Add(image);
            await context.SaveChangesAsync();
            int imageId = image.Id;
            return imageId;
        }

        public async Task<int> EditImage (Image image)
        {
            context.Update(image);
            await context.SaveChangesAsync();
            return image.Id;
        }
    }
}
