using ChillsoftMinutesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingItemRepository
    {
        Task<IEnumerable<MeetingItem>> GetAllMeetingItemsAsync();
        Task<bool> AddMeetingItemAsync(MeetingItem meetingItem);
        Task<bool> UpdateMeetingItemAsync(MeetingItem meetingItem);
        Task<MeetingItem> GetMeetingItemByIdAsync(string id);
        Task<IEnumerable<MeetingItem>> GetMeetingItemByMeeting(Meeting meeting);
        Task<IEnumerable<MeetingItem>> GetMeetingItemsByMeetingIdAsync(string id);
    }
}
