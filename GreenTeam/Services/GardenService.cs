using GreenTeam.Data;
using GreenTeam.Models;

namespace GreenTeam.Services
{
    public class GardenService : IGardenService
    {
        private ApplicationDbContext context;

        public GardenService(ApplicationDbContext context)
        {
            this.context = context;
         
        }

        public Garden FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
