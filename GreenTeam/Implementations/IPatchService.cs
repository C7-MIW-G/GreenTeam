using GreenTeam.Models;
using GreenTeam.ViewModels;

namespace GreenTeam.Implementations
{
    public interface IPatchService
    {
        Task<List<Patch>> FindByGardenId(int Id);
        Task<Patch> AddPatch(Patch patch);
        Task<Patch> FindById(int Id);
        Task<Patch> EditPatch(Patch patch);
        Task<Patch> DeletePatch(int Id);

        Task<PatchVM> GetVMById(int id);
        Task<PatchVM> GetDetailsVM(int id);
        Task<List<PatchVM>> GetAllPatchVMs();
        Task<int> GetGardenIdByPatchId(int patchId);
    }
}
