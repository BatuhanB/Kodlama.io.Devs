using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Update;

public class UpdateProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>
{
    public string Name { get; set; }
}