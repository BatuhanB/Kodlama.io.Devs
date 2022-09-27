using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetById;

public class GetByIdProgrammingLanguageQueryHandler:IRequestHandler<GetByIdProgrammingLanguageQuery,ProgrammingLanguageGetByIdDto>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _businessRules;

    public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.ProgrammingLanguageShouldExistWhenRequested(request.Id);
        var programmingLanguage = await _repository.GetAsync(x=>x.Id == request.Id);
        var programmingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
        return programmingLanguageGetByIdDto;
    }
}