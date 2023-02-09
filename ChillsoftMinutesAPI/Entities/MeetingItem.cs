namespace ChillsoftMinutesAPI.Entities
{
    public class MeetingItem
    {
        public int Id { get; set; }
        public Meeting Meeting { get; set; }
        public AppUser PersonResponsible { get; set; }
        public string Action { get; set; }
        public List<MeetingItemStatus> MeetingItemStatus { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set;} = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

    }
}