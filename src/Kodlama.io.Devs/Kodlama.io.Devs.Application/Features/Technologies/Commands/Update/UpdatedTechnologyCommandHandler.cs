using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.Update
{
    public class UpdatedTechnologyCommandHandler : IRequestHandler<UpdatedTechnologyCommand, UpdatedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public UpdatedTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTechnologyDto> Handle(UpdatedTechnologyCommand request, CancellationToken cancellationToken)
        {
            var technology = await _technologyRepository.GetAsync(x=>x.Id == request.Id);
            var mappedTechnology = _mapper.Map(request,technology);
            var updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
            var updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
            return updatedTechnologyDto;
        }
    }
}
