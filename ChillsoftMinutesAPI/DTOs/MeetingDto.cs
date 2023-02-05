using ChillsoftMinutesAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MeetingDto
    {
        [Required(ErrorMessage = "The MeetingType field is required.")]
        public string MeetingType { get; set; }
        [Required(ErrorMessage = "The DateHeld field is required.")]
        public DateTime DateHeld { get; set; }
        [Required(ErrorMessage = "The MinutesTaker field is required.")]
        public string MinutesTaker { get; set; }
        public string MeetingId { get; set; }
        
    }
}
