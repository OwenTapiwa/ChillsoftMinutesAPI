using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;

namespace ChillsoftMinutesAPI.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<UserDto> Register(RegisterDto registerDto);
    }
}
