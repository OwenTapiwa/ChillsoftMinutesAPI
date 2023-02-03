using Microsoft.AspNetCore.Identity;

namespace ChillsoftMinutesAPI.Entities
{
    public class Roles : IdentityRole<int>
    {
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
