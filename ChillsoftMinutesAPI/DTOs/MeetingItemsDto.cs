using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MeetingItemsDto
    {
        public int Id { get; set; }
        public MemberDto PersonResponsible { get; set; }
        public string Action { get; set; }
        public MeetingItemStatus MeetingItemStatus { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

    }
}
