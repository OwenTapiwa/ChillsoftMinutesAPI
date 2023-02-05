namespace ChillsoftMinutesAPI.Entities
{
    public class MeetingType
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string PreFix { get; set; }
    }
}