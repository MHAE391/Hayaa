using Business.DTOs.Branch;
using Business.DTOs.Response;
using Business.Repositories.Branches;
using MediatR;

namespace UseCases.BranchUseCases.Update
{
    public class UpdateBranchHandler(IBranchRepository repo) : IRequestHandler<UpdateBranchCommand, ResponseDTO<PreviewBranchDTO>>
    {
        public async Task<ResponseDTO<PreviewBranchDTO>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<PreviewBranchDTO> { IsSuccess = true };
            var agency = await repo.GetBranchByIdAsync(request.Id);
            if (agency is null)
            {
                response.IsSuccess = false;
                response.Errors = [$"No Branch with id '{request.Id}' Found !!"];
                return response;
            }
            if (agency.Name == request.Name)
            {
                response.IsSuccess = false;
                response.Errors = [$"Branch Name is same"];
                return response;
            }
            if (await repo.SearchBranchByNameAsync(request.Name) is not null)
            {
                response.IsSuccess = false;
                response.Errors = [$"Branch with name '{request.Name}' ,already exist !!"];
                return response;
            }
            var data = await repo.UpdateBranchAsync(agency!, request.Name);
            response.Data = new PreviewBranchDTO { Name = data.Name, Id = data.Id };
            return response;
        }
    }
}
