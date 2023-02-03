using ChillsoftMinutesAPI.Data;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Controllers
{
    public class AccountController : BaseApiController
    {
       
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            var userDto = await _authService.Login(loginDto);

            if(userDto.Message != "Success") return Unauthorized(userDto.Message);

            return Ok(userDto);

        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var userDto = await _authService.Register(registerDto);

            if (userDto.Message != "Success") return BadRequest(userDto.Message);

            return Ok(userDto);
        }

    }
}
