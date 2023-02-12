using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ChillsoftMinutesAPI.Controllers
{
    
    public class MeetingItemStatusController : BaseApiController
    {
        private readonly IMeetingItemStatusRepository _meetingItemStatusRepository;
        private readonly IMeetingItemStatusService _meetingItemStatusService;
        private readonly IMapper _mapper;
        public MeetingItemStatusController(IMeetingItemStatusRepository meetingItemStatusRepository, IMapper mapper, IMeetingItemStatusService meetingItemStatusService)
        {
            _meetingItemStatusRepository = meetingItemStatusRepository;
            _meetingItemStatusService = meetingItemStatusService;
            _mapper = mapper;
        }

        [HttpPost("addMeetingItemStatus")]
        public async Task<ActionResult<MeetingItemStatus>> AddMeetingItemStatus(MeetingItemStatusDto meetingItemStatusDto)
        {
            
            var meetingStatusResult = await _meetingItemStatusService.CreateMeetingItemStatus(meetingItemStatusDto);
            if (meetingStatusResult != null) return NoContent();
            return BadRequest("Failed to add item status");
        }

        [HttpPost("editMeetingItemStatus")]
        public async Task<ActionResult<MeetingItemStatus>> EditMeetingItemStatus(MeetingItemStatusDto meetingItemStatusDto)
        {
            var meetingItemStatus = new MeetingItemStatus();
            var meetingStatus = await _meetingItemStatusRepository.GetMeetingItemStatusByIdAsync(meetingItemStatusDto.Id);

            if (meetingStatus == null) return BadRequest("Item Status Not Found");

            _mapper.Map(meetingItemStatusDto, meetingItemStatus);
            meetingItemStatus.AddedDate = meetingStatus.AddedDate;
            if (await _meetingItemStatusRepository.UpdateMeetingItemStatusAsync(meetingItemStatus)) return NoContent();
            return BadRequest("Failed to add item status");
        }

    }
}
