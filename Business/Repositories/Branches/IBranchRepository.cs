using Database.Entities;

namespace Business.Repositories.Branches
{
    public interface IBranchRepository
    {
        public Task<Branch> CreateBranchAsync(Branch branch);
        public Task<Branch?> SearchBranchByNameAsync(string branch);

        public Task<IEnumerable<Branch>> GetAllBranchesAsync();
        public Task<Branch?> GetBranchByIdAsync(int id);

        public Task<Branch> DeleteBranchAsync(Branch branch);
        public Task<Branch> UpdateBranchAsync(Branch branch, string name);
    }
}
