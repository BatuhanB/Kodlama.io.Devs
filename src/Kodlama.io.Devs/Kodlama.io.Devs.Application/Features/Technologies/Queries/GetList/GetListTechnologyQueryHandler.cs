
using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetList
{
    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
            var listedTechnology = await _technologyRepository.GetListAsync(index: request.PageRequest.Page,
                                                                            size: request.PageRequest.PageSize,
                                                                            include: x => x.Include(x => x.ProgrammingLanguage));
            var mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(listedTechnology);
            return mappedTechnologyListModel;
        }
    }
}
