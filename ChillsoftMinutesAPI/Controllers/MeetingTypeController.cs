using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChillsoftMinutesAPI.Controllers
{
    
    public class MeetingTypeController : BaseApiController
    {
        private readonly IMeetingTypeRepository _meetingTypeRepository;

        public MeetingTypeController(IMeetingTypeRepository meetingTypeRepository)
        {
            _meetingTypeRepository = meetingTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingType>>> GetMeetingTypes()
        {
            var meetingTypes = await _meetingTypeRepository.GetMeetingTypesAsync();
            return Ok(meetingTypes);
        }

        [HttpPost("addMeetingType")]
        public async Task<ActionResult<MeetingType>> Register(MeetingTypeDto meetingTypeDto)
        {
            if (_meetingTypeRepository.MeetingTypeExists(meetingTypeDto.Name)) return BadRequest("Meeting Type Exists");
            //var school = new Schools();
            //_mapper.Map(schoolDto, school);
            if (await _meetingTypeRepository.AddTypeAsync(school)) return NoContent();
            return BadRequest("Failed to add meeting type");
        }
    }
}
