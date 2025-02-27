using Business.DTOs.Agency;
using Business.DTOs.Response;
using Business.Repositories.Agencies;
using MediatR;

namespace UseCases.AgencyUseCases.Preview
{
    public class GetAgencyByIdHandler(IAgencyRepository repo) : IRequestHandler<GetAgencyByIdQuery, ResponseDTO<PreviewAgancyDTO>>
    {
        public async Task<ResponseDTO<PreviewAgancyDTO>> Handle(GetAgencyByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repo.GetAgencyByIdAsync(request.Id);
            return new ResponseDTO<PreviewAgancyDTO>
            {
                IsSuccess = data is not null,
                Data = data is null ? null : new PreviewAgancyDTO { Name = data.Name, Id = data.Id },
                Errors = data is not null ? null : [$"No Agency with id '{request.Id}' "]
            };
        }
    }
}
