using ChillsoftMinutesAPI.Data;
using ChillsoftMinutesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingRepository
    {
        Task<IEnumerable<Meeting>> GetAllMeetingsAsync();
        Task<bool> AddMeetingAsync(Meeting meeting);
        Task<bool> UpdateMeetingAsync(Meeting meeting);
        Task<Meeting> PreviousMeeting(MeetingType meetingType);
        Task<Meeting> GetAllMeetingsByIdAsync(int meetingId);
    }
}
