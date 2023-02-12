using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingService
    {
        Task<Meeting> CreateMeeting(MeetingDto meetingDto);
        Task<Meeting> UpdateMeeting(MeetingDto meetingDto);
        Task<IEnumerable<MeetingResponseDto>> GetMeeting(int meetingId);
    }
}
