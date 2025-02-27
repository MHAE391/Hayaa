using Business.DTOs.Branch;
using Business.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCases.BranchUseCases.Create;
using UseCases.BranchUseCases.Delete;
using UseCases.BranchUseCases.Preview;
using UseCases.BranchUseCases.Update;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController(IMediator service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResponseDTO<PreviewBranchDTO>>> Create([FromBody] CreateBranchCommand command)
        {
            var response = await service.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<PreviewBranchDTO>>>> GetAll()
        {
            var response = await service.Send(new GetAllBranchesQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<PreviewBranchDTO>>> GetById(int id)
        {
            var response = await service.Send(new GetBranchByIdQuery { Id = id });
            return response.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<PreviewBranchDTO>>> DeleteById(int id)
        {
            var response = await service.Send(new DeleteBranchCommand { Id = id });
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<PreviewBranchDTO>>> UpdateAgency(int id, [FromBody] string name)
        {
            var response = await service.Send(new UpdateBranchCommand { Id = id, Name = name });
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
