using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetById;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest request)
        {
            GetListProgrammingLanguageQuery query = new() { PageRequest = request };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
