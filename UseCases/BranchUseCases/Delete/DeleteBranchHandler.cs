using Business.DTOs.Branch;
using Business.DTOs.Response;
using Business.Repositories.Branches;
using MediatR;

namespace UseCases.BranchUseCases.Delete
{
    public class DeleteBranchHandler(IBranchRepository repo) : IRequestHandler<DeleteBranchCommand, ResponseDTO<PreviewBranchDTO>>
    {
        public async Task<ResponseDTO<PreviewBranchDTO>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<PreviewBranchDTO> { IsSuccess = true };
            var branch = await repo.GetBranchByIdAsync(request.Id);
            if (branch is null)
            {
                response.IsSuccess = false;
                response.Errors = [$"No Branch with id '{request.Id}' Found !!"];
                return response;
            }
            var data = await repo.DeleteBranchAsync(branch!);
            response.Data = new PreviewBranchDTO { Name = data.Name, Id = data.Id };
            return response;
        }
    }
}
