
using Business.DTOs.Agency;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.AgencyUseCases.Create
{
    public record CreateAgencyCommand : IRequest<ResponseDTO<PreviewAgancyDTO>>
    {
        public required string Name { get; set; }
    }
}
