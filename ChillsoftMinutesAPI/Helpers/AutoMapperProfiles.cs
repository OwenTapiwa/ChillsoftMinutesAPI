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
            CreateMap<MeetingItemStatusDto, MeetingItemStatus>()
                .ForMember(x => x.LastUpdatedDate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<MeetingItem, MeetingItemsDto>()
                .ForMember(x => x.MeetingItemStatus, opt => opt.MapFrom(src => src.MeetingItemStatus.LastOrDefault(x => x.Status != "")))
                .ForMember(x => x.PersonResponsible, opt => opt.MapFrom(src => src.PersonResponsible))
                .ForMember(x => x.Id , opt => opt.MapFrom(src => src.Id));
            CreateMap<Meeting, MeetingResponseDto>();
            CreateMap<MeetingItem, MeetingItem>();
        }
    }
}
