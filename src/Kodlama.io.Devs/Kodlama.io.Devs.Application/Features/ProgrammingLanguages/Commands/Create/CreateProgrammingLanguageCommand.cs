using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommand:IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }
}