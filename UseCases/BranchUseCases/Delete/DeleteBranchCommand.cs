using Business.DTOs.Branch;
using Business.DTOs.Response;
using MediatR;
namespace UseCases.BranchUseCases.Delete
{
    public record DeleteBranchCommand : IRequest<ResponseDTO<PreviewBranchDTO>>
    {
        public int Id { get; set; }
    }
}
