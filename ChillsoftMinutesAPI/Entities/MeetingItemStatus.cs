namespace ChillsoftMinutesAPI.Entities
{
    public class MeetingItemStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public MeetingItem MeetingItem { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
