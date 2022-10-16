using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetList
{
    public class GetListTechnologyQuery:IRequest<TechnologyListModel>
    {
        public PageRequest? PageRequest { get; set; }
    }
}
