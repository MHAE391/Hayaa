using Business.DTOs.Agency;
using Business.DTOs.Response;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories.Agencies
{
    public class AgencyRepository(ApplicationDbContext context) : IAgencyRepository
    {
        public async Task<Agency> CreateAgencyAsync(Agency agency)
        {
            await context.Agencies.AddAsync(agency);
            await context.SaveChangesAsync();
            return agency;
        }

        public async Task<Agency> DeleteAgencyAsync(Agency agency)
        {

            context.Agencies.Remove(agency);
            await context.SaveChangesAsync();
            return agency;
        }

        public async Task<Agency?> GetAgencyByIdAsync(int id) => await context.Agencies.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Agency>> GetAllAgenciesAsync() => await context.Agencies.ToListAsync();
        public async Task<bool> SearchAgencyByNameAsync(string agency) => await context.Agencies.FirstOrDefaultAsync(A => A.Name == agency) is not null;

        public async Task<Agency> UpdateAgencyAsync(Agency agency , string name)
        {
            agency.Name = name;
            context.Agencies.Update(agency);
            await context.SaveChangesAsync();
            return agency ;
        }
    }
}
