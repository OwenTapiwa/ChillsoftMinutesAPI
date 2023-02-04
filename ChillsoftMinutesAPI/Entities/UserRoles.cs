using Microsoft.AspNetCore.Identity;
using System.Data;

namespace ChillsoftMinutesAPI.Entities
{
    public class UserRoles : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public Roles Role { get; set; }
    }
}
