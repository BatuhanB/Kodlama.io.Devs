using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetList;

public class GetListProgrammingLanguageQueryHandler:IRequestHandler<GetListProgrammingLanguageQuery,ProgrammingLanguageListModel>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;

    public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        var programmingLanguage = await _repository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);
        return mappedProgrammingLanguageListModel;
    }
}