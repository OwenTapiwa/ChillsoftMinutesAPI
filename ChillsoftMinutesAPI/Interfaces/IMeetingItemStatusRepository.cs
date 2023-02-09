using ChillsoftMinutesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingItemStatusRepository
    {
        Task<IEnumerable<MeetingItemStatus>> GetMeetingItemStatusesAsync();
        Task<bool> AddMeetingItemStatusAsync(MeetingItemStatus meetingItemStatus);
        Task<MeetingItemStatus> GetMeetingItemStatusByIdAsync(string id);
        Task<bool> UpdateMeetingItemStatusAsync(MeetingItemStatus meetingItemStatus);

    }
}
