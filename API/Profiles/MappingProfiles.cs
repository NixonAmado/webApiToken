
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<RefreshToken,RefreshTokenDto>()
        .ForMember(dest => dest.AccessKey, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.ExpirationDateKey, opt => opt.MapFrom(src => src.ExpirationDate))
        .ReverseMap();
        
        }
}