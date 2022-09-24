using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Delete;

public class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
{
    public string Name { get; set; }
}