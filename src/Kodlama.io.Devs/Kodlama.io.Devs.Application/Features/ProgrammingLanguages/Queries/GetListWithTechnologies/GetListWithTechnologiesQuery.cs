using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListWithTechnologies
{
    public class GetListWithTechnologiesQuery:IRequest<ProgramminLanguageWithTechnologiesListModel>
    {
        public PageRequest? PageRequest { get; set; }
    }
}
