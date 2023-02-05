using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IMeetingTypeRepository
    {
        Task<IEnumerable<MeetingType>> GetMeetingTypesAsync();
        Task<bool> AddTypeAsync(MeetingType meetingType);
        Task<bool> RemoveTypeAsync(MeetingType meetingType);
        bool MeetingTypeExists(string meetingType);
        Task<MeetingType> GetMeetingTypeByName(string name);

    }
}
