using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingItemStatusService
    {
        Task<MeetingItemStatus> CreateMeetingItemStatus(MeetingItemStatusDto meetingItemStatusDto);
    }
}
