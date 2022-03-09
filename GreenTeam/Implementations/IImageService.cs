using GreenTeam.Models;

namespace GreenTeam.Implementations
{
    public interface IImageService
    {
        Task<int> AddImage(Image image);
    }
}
