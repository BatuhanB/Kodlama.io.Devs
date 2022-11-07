
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.Delete
{
    public class DeletedTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
    }
}
