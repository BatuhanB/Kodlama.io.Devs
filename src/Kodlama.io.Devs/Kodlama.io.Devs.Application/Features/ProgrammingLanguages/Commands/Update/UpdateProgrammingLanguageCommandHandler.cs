using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Update;

public class UpdateProgrammingLanguageCommandHandler:IRequestHandler<UpdateProgrammingLanguageCommand,UpdatedProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        var programmingLanguage = await _repository.GetAsync(x=>x.Id == request.Id);
        var mappedProgrammingLanguage = _mapper.Map(request, programmingLanguage); 
        var updatedProgrammingLanguage = await _repository.UpdateAsync(mappedProgrammingLanguage);
        var updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
        return updatedProgrammingLanguageDto;
    }
}