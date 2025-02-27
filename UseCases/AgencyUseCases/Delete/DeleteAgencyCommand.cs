
using Business.DTOs.Agency;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.AgencyUseCases.Delete
{
    public record DeleteAgencyCommand : IRequest<ResponseDTO<PreviewAgancyDTO>>
    {
        public int Id { get; set; }
    }
}
