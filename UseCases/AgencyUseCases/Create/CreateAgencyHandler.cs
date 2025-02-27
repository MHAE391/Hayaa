using Business.DTOs.Agency;
using Business.DTOs.Response;
using Business.Repositories.Agencies;
using Database.Entities;
using MediatR;

namespace UseCases.AgencyUseCases.Create
{
    public class CreateAgencyHandler(IAgencyRepository repo) : IRequestHandler<CreateAgencyCommand, ResponseDTO<PreviewAgancyDTO>>
    {
        public async Task<ResponseDTO<PreviewAgancyDTO>> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
        {
            var isExist = await repo.SearchAgencyByNameAsync(request.Name);
            ResponseDTO<PreviewAgancyDTO> response = new() { IsSuccess = true };
            if (isExist) 
            { 
                response.IsSuccess = false;
                response.Errors = [$"Agancy with name '{request.Name}' ,already exist !!"];
                return response; 
            }
            try
            {
                var newAgency = await repo.CreateAgencyAsync(new Agency { Name = request.Name });
                response.Data = new PreviewAgancyDTO { Id = newAgency.Id , Name = newAgency.Name };
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
