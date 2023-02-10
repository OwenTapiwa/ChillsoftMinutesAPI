using ChillsoftMinutesAPI.Data.Repositories;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingItemService
    {
        Task<MeetingItem> CreateMeetingItem(MeetingItemDto meetingItemDto);
        Task<MeetingItem> UpdateMeetingItem(MeetingItemDto meetingItemDto);
        Task<IEnumerable<MeetingItemsDto>> GetMeetingItems(int meetingId);
    }
}
