using Business.DTOs.Agency;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.AgencyUseCases.Update
{
    public class UpdateAgencyCommand : IRequest<ResponseDTO<PreviewAgancyDTO>>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
