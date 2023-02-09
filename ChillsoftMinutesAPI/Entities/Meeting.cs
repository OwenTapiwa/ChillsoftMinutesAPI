namespace ChillsoftMinutesAPI.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public string MeetingId { get; set; }
        public MeetingType? MeetingType { get; set; }
        public DateTime DateHeld { get; set; } = DateTime.Now;
        public List<MeetingItem>? MeetingItem  { get; set; }
        public AppUser? MinutesTaker { get; set; }
    }
}
