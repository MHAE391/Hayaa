using Business.DTOs.Agency;
using Business.DTOs.Response;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.Agencies
{
    public interface IAgencyRepository
    {
        public Task<Agency> CreateAgencyAsync(Agency agency);
        public Task<bool> SearchAgencyByNameAsync(string agency);

        public Task<IEnumerable<Agency>> GetAllAgenciesAsync();
        public Task<Agency?> GetAgencyByIdAsync(int id);

        public Task<Agency> DeleteAgencyAsync(Agency agency);
        public Task<Agency> UpdateAgencyAsync (Agency agency , string name);
    }
}
