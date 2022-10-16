using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.Create;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;


namespace Kodlama.io.Devs.Application.Features.Teckhnologies.Commands.Create
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper,TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInserted(request.Name);
            var mappedTechnology = _mapper.Map<Technology>(request);
            var createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
            var createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology);
            return createdTechnologyDto;

        }
    }
}
