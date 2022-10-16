
using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetById
{
    public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper,TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
        {
            await _technologyBusinessRules.TechnologyShouldExistWhenRequested(request.Id);
            var technology = await _technologyRepository.GetAsync(x=>x.Id == request.Id,include:x=>x.Include(x=>x.ProgrammingLanguage));
            var mappedTechnologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);
            return mappedTechnologyGetByIdDto;
        }
    }
}
