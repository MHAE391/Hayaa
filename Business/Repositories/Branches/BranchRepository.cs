using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories.Branches
{
    public class BranchRepository(ApplicationDbContext context) : IBranchRepository
    {
        public async Task<Branch> CreateBranchAsync(Branch branch)
        {
            await context.Branches.AddAsync(branch);
            await context.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch> DeleteBranchAsync(Branch branch)
        {
            context.Branches.Remove(branch);
            await context.SaveChangesAsync();
            return branch;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync() => await context.Branches.ToListAsync();
        public async Task<Branch?> GetBranchByIdAsync(int id) => await context.Branches.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Branch?> SearchBranchByNameAsync(string branch) => await context.Branches.FirstOrDefaultAsync(x => x.Name == branch);

        public async Task<Branch> UpdateBranchAsync(Branch branch, string name)
        {
            branch.Name = name;
            context.Branches.Update(branch);
            await context.SaveChangesAsync();
            return branch;
        }
    }
}
