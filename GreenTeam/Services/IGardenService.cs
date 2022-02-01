using GreenTeam.Models;

namespace GreenTeam.Services
{
    public interface IGardenService
    {
        Task<Garden> FindById(int Id);
        Task<List<Garden>> FindAll();
    }
}
