
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetById
{
    public class GetByIdTechnologyQuery:IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }
    }
}
