using ChillsoftMinutesAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MeetingItemStatusDto
    {
        [Required(ErrorMessage = "The Id field is required.")]
        public string Id { get; set; }
        [Required(ErrorMessage = "The Status field is required.")]
        public string Status { get; set; }
      
    }
}
