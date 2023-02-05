using ChillsoftMinutesAPI.Entities;
using AutoMapper;
using ChillsoftMinutesAPI.Extensions;
using ChillsoftMinutesAPI.DTOs;



namespace ChillsoftMinutesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MeetingTypeDto, MeetingType>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name.ToUpper().Trim()));
            CreateMap<AppUser, MemberDto>();
        }
    }
}
