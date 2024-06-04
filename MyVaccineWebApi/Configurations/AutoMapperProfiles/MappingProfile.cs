using AutoMapper;
using MyVaccineWebApi.Dtos.Dependent;
using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Configurations.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dependent, DependentRequestDto>().ReverseMap();
            CreateMap<Dependent, DependentResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DependentId)).ReverseMap();
        }
    }
}
