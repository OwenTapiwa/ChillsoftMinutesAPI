using System.ComponentModel.DataAnnotations;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MeetingTypeDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Prefix field is required.")]
        public string PreFix { get; set; }
    }
}
