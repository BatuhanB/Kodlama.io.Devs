using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Delete;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Update;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetById;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetList;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListWithTechnologies;
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
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest request)
        {
            GetListProgrammingLanguageQuery query = new() { PageRequest = request };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListWithTechnologies([FromQuery] PageRequest request)
        {
            GetListWithTechnologiesQuery query = new() { PageRequest = request };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }
    }
}
