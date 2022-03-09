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
               
        public async Task<int> AddImage(Image Image)
        {
            context.Add(Image);
            await context.SaveChangesAsync();
            int imageId = Image.Id;
            return imageId;
        }
    }
}
