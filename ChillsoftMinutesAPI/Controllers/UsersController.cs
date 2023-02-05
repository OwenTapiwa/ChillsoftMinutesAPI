using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChillsoftMinutesAPI.Controllers
{
   
    public class UsersController : BaseApiController
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _usersRepository.GetSystemUsersAsync();
            return Ok(users);
        }
        // GET: api/Users
        [HttpGet("users")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            var users = await _usersRepository.GetUsersAsync();
            return Ok(users);
        }
        // GET: api/Users/5
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetAppUser(string username)
        {
            return await _usersRepository.GetSystemUserAsync(username);
        }
    }
}
