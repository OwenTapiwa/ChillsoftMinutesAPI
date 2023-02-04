using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
