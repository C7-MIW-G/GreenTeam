using GreenTeam.Models;

namespace GreenTeam.Implementations
{
    public interface IImageService
    {
        Task<int> AddImage(Image image);
        Task<int> EditImage(Image image);
    }
}
