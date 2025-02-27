using Business.DTOs.Branch;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.BranchUseCases.Update
{
    public record UpdateBranchCommand : IRequest<ResponseDTO<PreviewBranchDTO>>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
