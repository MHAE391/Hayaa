using Business.DTOs.Branch;
using Business.DTOs.Response;
using Business.Repositories.Branches;
using MediatR;

namespace UseCases.BranchUseCases.Preview
{
    public class GetBranchByIdHandler(IBranchRepository repo) : IRequestHandler<GetBranchByIdQuery, ResponseDTO<PreviewBranchDTO>>
    {
        public async Task<ResponseDTO<PreviewBranchDTO>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repo.GetBranchByIdAsync(request.Id);
            return new ResponseDTO<PreviewBranchDTO>
            {
                IsSuccess = data is not null,
                Data = data is null ? null : new PreviewBranchDTO { Name = data.Name, Id = data.Id },
                Errors = data is not null ? null : [$"No Branch with id '{request.Id}' "]
            };
        }
    }
}
