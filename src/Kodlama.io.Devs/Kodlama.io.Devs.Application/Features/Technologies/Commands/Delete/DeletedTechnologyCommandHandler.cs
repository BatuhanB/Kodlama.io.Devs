using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.Delete
{
    public class DeletedTechnologyCommandHandler : IRequestHandler<DeletedTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public DeletedTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTechnologyDto> Handle(DeletedTechnologyCommand request, CancellationToken cancellationToken)
        {
            var mappedTechnology = _mapper.Map<Technology>(request);
            var deletedTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);
            var deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
            return deletedTechnologyDto;
        }
    }
}
