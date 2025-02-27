using Business.DTOs.Branch;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.BranchUseCases.Create
{
    public record CreateBranchCommand : IRequest<ResponseDTO<PreviewBranchDTO>>
    {
        public required string  Name { get; set; }
    }
}
