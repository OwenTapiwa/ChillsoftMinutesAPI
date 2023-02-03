using ChillsoftMinutesAPI.Data;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChillsoftMinutesAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {

            var userDto = new UserDto();

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null)
            {
                userDto.Message = "Invalid Username";
                return userDto;
            }

            if (user.IsDeleted)
            {
                userDto.Message = "Account Deleted";
                return userDto;
            }

            if (user.LockedOut)
            {
                userDto.Message = "Account Locked";
                return userDto;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                userDto.Message = "Invalid Password";
                return userDto;
            }

            userDto.Message = "Success";
            userDto.Username = user.UserName;
            userDto.Token = await _tokenService.CreateToken(user);
            return userDto;
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            Guid userGuid = Guid.NewGuid();
            var userDto = new UserDto();
            if (await AppUserExists(registerDto.EmailAddress))
            {
                userDto.Message = "Username / User Exists!";
                return userDto;
            }

            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.EmailAddress,
                PhoneNumber = registerDto.PhoneNumber,
                EmailAddress = registerDto.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                userDto.Message = result.Errors.ToString();
                return userDto;
            }

            userDto.Message = "Success";
            userDto.Username = user.UserName;
            userDto.Token = await _tokenService.CreateToken(user);
            return userDto;
        }

        private async Task<bool> AppUserExists(string email)
        {
            return _userManager.Users.Any(e => e.EmailAddress.ToLower() == email.ToLower());
        }
    }
}
