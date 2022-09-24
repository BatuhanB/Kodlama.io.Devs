using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommandHandler:IRequestHandler<CreateProgrammingLanguageCommand,CreatedProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _businessRules;

    public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.ProgrammingLanguageCanNotBeDuplicatedWhenInserted(request.Name);
        var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
        var createdProgrammingLanguage = await _repository.AddAsync(mappedProgrammingLanguage);
        var createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);
        return createdProgrammingLanguageDto;
    }
}