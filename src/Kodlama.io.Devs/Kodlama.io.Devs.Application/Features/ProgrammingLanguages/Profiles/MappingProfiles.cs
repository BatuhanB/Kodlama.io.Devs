using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Delete;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Update;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
    }
}