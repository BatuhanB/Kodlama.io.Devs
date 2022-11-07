using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Delete;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Update;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
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

        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, ProgramminLanguageWithTechnologiesListModel>().ReverseMap();

        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

        CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageWithTechnologiesDto>().ForMember(x => x.Technologies,
            opt => opt.MapFrom(x=>x.Technologies));
    }
}