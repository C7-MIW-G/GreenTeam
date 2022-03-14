using GreenTeam.Models;

namespace GreenTeam.Implementations
{
    public interface IPatchTaskService
    {
        Task<List<PatchTask>> FindByPatchId(int Id);
        Task<PatchTask> AddPatchTask(PatchTask patchTask);
        Task<PatchTask> FindById(int Id);
        Task<PatchTask> EditPatchTask(PatchTask patchTask);
        Task<PatchTask> DeletePatchTask(int Id);
        Task<PatchTask> CompletePatchTask(int Id);
        Task<PatchTask> SoftDeletePatchTask(int Id);
    }
}
