using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IUsersRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(string id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetSystemUsersAsync();
        Task<MemberDto> GetSystemUserAsync(string username);
    }
}
