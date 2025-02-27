using Business.DTOs.Branch;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.BranchUseCases.Preview
{
    public record GetBranchByIdQuery : IRequest<ResponseDTO<PreviewBranchDTO>>
    {
        public int Id { get; set; } 
    }
}
