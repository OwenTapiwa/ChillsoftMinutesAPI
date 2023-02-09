using ChillsoftMinutesAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MeetingItemDto
    {
        [Required(ErrorMessage = "The Meeting Id field is required.")]
        public string MeetingId { get; set; }
        [Required(ErrorMessage = "The Person Responsible field is required.")]
        public string  PersonResponsible { get; set; }
        [Required(ErrorMessage = "The Action field is required.")]
        public string Action { get; set; }
        [Required(ErrorMessage = "The Due Date field is required.")]
        public DateTime DueDate { get; set; }
        public string MeetingItemId { get; set; }

    }
}
