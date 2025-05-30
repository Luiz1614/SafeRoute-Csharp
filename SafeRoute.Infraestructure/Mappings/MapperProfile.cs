using AutoMapper;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
using SafeRoute.Domain.Entities;

namespace SafeRoute.Infraestructure.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserRequestDto>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();

        CreateMap<ClimaticEvent, ClimaticEventRequestDto>().ReverseMap();
        CreateMap<ClimaticEvent, ClimaticEventResponseDto>().ReverseMap();

        CreateMap<SafeResource, SafeResourceRequestDto>().ReverseMap();
        CreateMap<SafeResource, SafeResourceResponseDto>().ReverseMap();
    }
}
