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
        private readonly IMapper _mapper;

        public MeetingTypeController(IMeetingTypeRepository meetingTypeRepository, IMapper mapper)
        {
            _meetingTypeRepository = meetingTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingType>>> GetMeetingTypes()
        {
            var meetingTypes = await _meetingTypeRepository.GetMeetingTypesAsync();
            return Ok(meetingTypes);
        }

        [HttpPost("addMeetingType")]
        public async Task<ActionResult<MeetingType>> AddMeetingType(MeetingTypeDto meetingTypeDto)
        {
            if (_meetingTypeRepository.MeetingTypeExists(meetingTypeDto.Name)) return BadRequest("Meeting Type Exists");
            var meetingType = new MeetingType();
            _mapper.Map(meetingTypeDto, meetingType);
            if (await _meetingTypeRepository.AddTypeAsync(meetingType)) return NoContent();
            return BadRequest("Failed to add meeting type");
        }

        [HttpPost("removeMeetingType")]
        public async Task<ActionResult<MeetingType>> RemoveMeetingType(MeetingTypeDto meetingTypeDto)
        {
            if (!_meetingTypeRepository.MeetingTypeExists(meetingTypeDto.Name)) return BadRequest("Meeting Type Not Found");
            var meetingType = new MeetingType();
            _mapper.Map(meetingTypeDto, meetingType);
            if (await _meetingTypeRepository.RemoveTypeAsync(meetingType)) return NoContent();
            return BadRequest("Failed to remove meeting type");
        }
    }
}
