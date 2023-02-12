using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChillsoftMinutesAPI.Controllers
{
    
    public class MeetingController : BaseApiController
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingRepository meetingRepository,IMeetingService meetingService, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
        {
            var meetings = await _meetingRepository.GetAllMeetingsAsync();
            return Ok(meetings);
        }
        [HttpGet("meeting/meetingId")]
        public async Task<ActionResult<IEnumerable<MeetingResponseDto>>> GetMeetings(int meetingId)
        {
            var meetings = await _meetingService.GetMeeting(meetingId);
            return Ok(meetings);
        }
        [HttpPost("addMeeting")]
        public async Task<ActionResult<MeetingResponseDto>> AddMeeting(MeetingDto meetingDto)
        {
            var meeting = await _meetingService.CreateMeeting(meetingDto);
            if(meeting != null)  return NoContent();
            return BadRequest("Failed to add meeting");
        }

        [HttpPost("updateMeeting")]
        public async Task<ActionResult<MeetingResponseDto>> UpdateMeeting(MeetingDto meetingDto)
        {
            var meeting = await _meetingService.UpdateMeeting(meetingDto);
            if (meeting != null) return NoContent();
            return BadRequest("Failed to update meeting");
        }
    }
}
