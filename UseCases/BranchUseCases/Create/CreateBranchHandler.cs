using Business.DTOs.Agency;
using Business.DTOs.Branch;
using Business.DTOs.Response;
using Business.Repositories.Branches;
using Database.Entities;
using MediatR;

namespace UseCases.BranchUseCases.Create
{
    public class CreateBranchHandler(IBranchRepository repo) : IRequestHandler<CreateBranchCommand, ResponseDTO<PreviewBranchDTO>>
    {
        public async Task<ResponseDTO<PreviewBranchDTO>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var isExist = await repo.SearchBranchByNameAsync(request.Name) is not null;
            ResponseDTO<PreviewBranchDTO> response = new() { IsSuccess = true };
            if (isExist)
            {
                response.IsSuccess = false;
                response.Errors = [$"Branch with name '{request.Name}' ,already exist !!"];
                return response;
            }
            try
            {
                var newAgency = await repo.CreateBranchAsync(new Branch { Name = request.Name });
                response.Data = new PreviewBranchDTO { Id = newAgency.Id, Name = newAgency.Name };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = [ex.Message];
            }
            return response;
        }
    }
}
