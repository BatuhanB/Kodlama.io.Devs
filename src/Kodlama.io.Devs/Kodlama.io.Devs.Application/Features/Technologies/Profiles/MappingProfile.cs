using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.Create;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.Delete;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.Update;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetById;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetList;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Technology,CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology,CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology,DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology,DeletedTechnologyCommand>().ReverseMap();

            CreateMap<Technology,UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology,UpdatedTechnologyCommand>().ReverseMap();

            CreateMap<Technology,TechnologyGetByIdDto>().ReverseMap();
            CreateMap<Technology,TechnologyListDto>().ReverseMap();
            
            CreateMap<IPaginate<Technology>,TechnologyListModel>().ReverseMap();
        }
    }
}
