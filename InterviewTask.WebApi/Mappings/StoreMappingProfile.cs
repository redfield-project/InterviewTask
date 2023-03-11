namespace InterviewTask.WebApi.Mappings;

using AutoMapper;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.Common.Models;
using InterviewTask.Common.Models.Responses;

public class StoreMappingProfile : Profile
{
    public StoreMappingProfile()
    {
        CreateMap<Store, StoreDTO>().ReverseMap();

        CreateMap<Store, StatisticsResponse>()
            .ForMember(dest => dest.Id,
            opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.City,
            opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country,
            opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Statistics,
            opt => opt.Ignore())
            .ForMember(dest => dest.Status,
            opt => opt.Ignore())
            .ForMember(dest => dest.Message,
            opt => opt.Ignore());
    }
}
