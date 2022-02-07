﻿using GreenTeam.Models;

namespace GreenTeam.Services
{
    public interface IPatchService
    {
        Task<List<Patch>> FindByGardenId(int Id);
        Task<Patch> AddPatch(Patch patch);
        Task<Patch> FindById(int Id);
        Task<Patch> EditPatch(Patch patch);
        Task<Patch> DeletePatch(int Id);
    }
}
