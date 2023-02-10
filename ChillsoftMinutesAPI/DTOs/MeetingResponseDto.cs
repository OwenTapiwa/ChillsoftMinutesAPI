using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MeetingResponseDto
    {
        public int Id { get; set; }
        public string MeetingId { get; set; }
        public MeetingType? MeetingType { get; set; }
        public DateTime DateHeld { get; set; } = DateTime.Now;
        public List<MeetingItemsDto>? MeetingItem { get; set; }
        public AppUser? MinutesTaker { get; set; }
    }
}
