
using Business.DTOs.Branch;
using Business.DTOs.Response;
using MediatR;

namespace UseCases.BranchUseCases.Preview
{
    public record GetAllBranchesQuery : IRequest<ResponseDTO< IEnumerable<PreviewBranchDTO>>>
    {

    }
}
