
using Business.DTOs.Agency;
using Business.DTOs.Response;
using Business.Repositories.Agencies;
using MediatR;

namespace UseCases.AgencyUseCases.Delete
{
    public class DeleteAgencyHandler(IAgencyRepository repo) : IRequestHandler<DeleteAgencyCommand, ResponseDTO<PreviewAgancyDTO>>
    {
        public async Task<ResponseDTO<PreviewAgancyDTO>> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<PreviewAgancyDTO> { IsSuccess = true };
            var agency = await repo.GetAgencyByIdAsync(request.Id);
            if (agency is null)
            {
                response.IsSuccess = false;
                response.Errors = [ $"No Agency with id '{request.Id}' Found !!"];
                return response;
            }
            var data = await repo.DeleteAgencyAsync(agency!);
            response.Data = new PreviewAgancyDTO { Name = data.Name , Id = data.Id};
            return response;
        }
    }
}
