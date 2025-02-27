
using Business.DTOs.Branch;
using Business.DTOs.Response;
using Business.Repositories.Branches;
using MediatR;

namespace UseCases.BranchUseCases.Preview
{
    public class GetAllBranchesHandler(IBranchRepository repo) : IRequestHandler<GetAllBranchesQuery, ResponseDTO<IEnumerable<PreviewBranchDTO>>>
    {
        public async Task<ResponseDTO<IEnumerable< PreviewBranchDTO>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<PreviewBranchDTO> data = (await repo.GetAllBranchesAsync()).Select(x => new PreviewBranchDTO { Name = x.Name, Id = x.Id }).ToList();
            return new ResponseDTO<IEnumerable<PreviewBranchDTO>>
            {
                IsSuccess = true,
                Data = data
            };
        }
    }
}

