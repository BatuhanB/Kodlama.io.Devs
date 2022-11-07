using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListWithTechnologies
{
    public class GetListWithTechnologiesQueryHandler : IRequestHandler<GetListWithTechnologiesQuery, ProgramminLanguageWithTechnologiesListModel>
    {
        private readonly IProgrammingLanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListWithTechnologiesQueryHandler(IMapper mapper, IProgrammingLanguageRepository languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<ProgramminLanguageWithTechnologiesListModel> Handle(GetListWithTechnologiesQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguage = await _languageRepository.GetListAsync(
                                      index: request.PageRequest.Page,
                                      size: request.PageRequest.PageSize,
                                      cancellationToken: cancellationToken,
                                      include: x => x.Include(x => x.Technologies));
            var programmingLanguageListModel = _mapper.Map<ProgramminLanguageWithTechnologiesListModel>(programmingLanguage);
            return programmingLanguageListModel;
        }
    }
}
