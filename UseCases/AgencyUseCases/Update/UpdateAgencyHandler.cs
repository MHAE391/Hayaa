using Business.DTOs.Agency;
using Business.DTOs.Response;
using Business.Repositories.Agencies;
using MediatR;

namespace UseCases.AgencyUseCases.Update
{
    internal class UpdateAgencyHandler(IAgencyRepository repo) : IRequestHandler<UpdateAgencyCommand, ResponseDTO<PreviewAgancyDTO>>
    {
        public async Task<ResponseDTO<PreviewAgancyDTO>> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<PreviewAgancyDTO> { IsSuccess = true };
            var agency = await repo.GetAgencyByIdAsync(request.Id);
            if (agency is null)
            {
                response.IsSuccess = false;
                response.Errors = [$"No Agency with id '{request.Id}' Found !!"];
                return response;
            }
            if (agency.Name == request.Name) 
            {
                response.IsSuccess = false;
                response.Errors = [$"Agency Name is same"];
                return response;
            }
            if (await repo.SearchAgencyByNameAsync(request.Name)) 
            {
                response.IsSuccess = false;
                response.Errors = [$"Agancy with name '{request.Name}' ,already exist !!"];
                return response;
            }
            var data = await repo.UpdateAgencyAsync(agency! , request.Name);
            response.Data = new PreviewAgancyDTO { Name = data.Name, Id = data.Id };
            return response;
        }
    }
}
