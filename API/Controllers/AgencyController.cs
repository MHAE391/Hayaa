using Business.DTOs.Agency;
using Business.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCases.AgencyUseCases.Create;
using UseCases.AgencyUseCases.Delete;
using UseCases.AgencyUseCases.Preview;
using UseCases.AgencyUseCases.Update;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController(IMediator service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult <ResponseDTO<PreviewAgancyDTO>>> Create([FromBody] CreateAgencyCommand command)
        {
            var response = await service.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response); 
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<PreviewAgancyDTO>>>> GetAll()
        {
            var response = await service.Send(new GetAllAgenciesQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<PreviewAgancyDTO>>> GetById(int id)
        { 
            var response = await service.Send(new GetAgencyByIdQuery { Id = id });
            return response.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<PreviewAgancyDTO>>> DeleteById(int id)
        {
            var response = await service.Send(new DeleteAgencyCommand { Id = id });
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<PreviewAgancyDTO>>> UpdateAgency(int id, [FromBody] string name)
        {
            var response = await service.Send(new UpdateAgencyCommand { Id = id , Name = name});
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
