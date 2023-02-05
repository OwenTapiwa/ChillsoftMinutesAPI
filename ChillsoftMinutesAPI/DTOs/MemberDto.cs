using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.DTOs
{
    public class MemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string EmailAddress { get; set; }
      
    }
}
