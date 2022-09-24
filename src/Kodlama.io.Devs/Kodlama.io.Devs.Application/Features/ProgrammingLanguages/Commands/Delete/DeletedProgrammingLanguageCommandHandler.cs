using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Delete;

public class DeletedProgrammingLanguageCommandHandler:IRequestHandler<DeleteProgrammingLanguageCommand,DeletedProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;

    public DeletedProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
        var deletedProgrammingLanguage = await _repository.DeleteAsync(mappedProgrammingLanguage);
        var deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
        return deletedProgrammingLanguageDto;
    }
}