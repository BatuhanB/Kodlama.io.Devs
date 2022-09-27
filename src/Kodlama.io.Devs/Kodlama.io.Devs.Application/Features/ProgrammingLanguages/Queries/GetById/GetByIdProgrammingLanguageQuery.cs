using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetById;

public class GetByIdProgrammingLanguageQuery:IRequest<ProgrammingLanguageGetByIdDto>
{
    public int Id { get; set; }
}