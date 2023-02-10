using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChillsoftMinutesAPI.Controllers
{
    public class MeetingItemsController : BaseApiController
    {
        private readonly IMeetingItemRepository _meetingItemRepository;
        private readonly IMeetingItemService _meetingItemService;
        private readonly IMapper _mapper;

        public MeetingItemsController(IMeetingItemRepository meetingItemRepository, IMeetingItemService meetingItemService, IMapper mapper)
        {
            _meetingItemRepository = meetingItemRepository;
            _mapper = mapper;
            _meetingItemService = meetingItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingItem>>> GetMeetingItem()
        {
            var meetingItems = await _meetingItemRepository.GetAllMeetingItemsAsync();
            return Ok(meetingItems);
        }

        [HttpGet("meetingItems/meetingId")]
        public async Task<ActionResult<IEnumerable<MeetingItemsDto>>> GetMeetingItems(int meetingId)
        {
            var meetingItems = await _meetingItemService.GetMeetingItems(meetingId);
            return Ok(meetingItems);
        }

        [HttpPost("addMeetingItem")]
        public async Task<ActionResult<MeetingItem>> AddMeetingItem(MeetingItemDto meetingItemDto)
        {
            var meetingItem = await _meetingItemService.CreateMeetingItem(meetingItemDto);
            if (meetingItem != null) return Ok(meetingItem);
            return BadRequest("Failed to add meeting item");
        }

        [HttpPost("updateMeeting")]
        public async Task<ActionResult<Meeting>> UpdateMeeting(MeetingItemDto meetingItemDto)
        {
            var meeting = await _meetingItemService.UpdateMeetingItem(meetingItemDto);
            if (meeting != null) return Ok(meeting);
            return BadRequest("Failed to update meeting");
        }
    }
}
