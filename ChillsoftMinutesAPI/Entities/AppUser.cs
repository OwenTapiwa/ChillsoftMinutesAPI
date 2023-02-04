using Microsoft.AspNetCore.Identity;

namespace ChillsoftMinutesAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string EmailAddress { get; set; }
        public int AccessFailedCount { get; set; } = 0;
        public DateTime DateLastLoggedIn { get; set; } = DateTime.Now;
        public ICollection<UserRoles> UserRoles { get; set; }
        public bool LockedOut { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DateDeleted { get; set; } = DateTime.Now;
        public string? DeletedBy { get; set; }

    }
}
