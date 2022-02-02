using GreenTeam.Models;

namespace GreenTeam.Services
{
    public interface IPatchService
    {
        Task<Patch> FindById(int Id);
        Task<List<Patch>> FindAll();
        Task<Patch> AddPatch(Patch patch);
        Task<Patch> EditPatch(Patch patch);
        Task<Patch> DeletePatch(int id);
    }
}
