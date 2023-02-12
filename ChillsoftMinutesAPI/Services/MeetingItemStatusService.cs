using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;

namespace ChillsoftMinutesAPI.Services
{
    public class MeetingItemStatusService : IMeetingItemStatusService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMeetingItemRepository _meetingItemRepository;
        private readonly IMeetingItemStatusRepository _meetingItemStatusRepository;
        private readonly IUsersRepository _usersRepository;

        private readonly IMapper _mapper;
        public MeetingItemStatusService(IMeetingRepository meetingRepository, IMeetingItemRepository meetingItemRepository, IMapper mapper, IUsersRepository usersRepository, IMeetingItemStatusRepository meetingItemStatusRepository)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _meetingItemRepository = meetingItemRepository;
            _usersRepository = usersRepository;
            _meetingItemStatusRepository = meetingItemStatusRepository;
        }

        public async Task<MeetingItemStatus> CreateMeetingItemStatus(MeetingItemStatusDto meetingItemStatusDto)
        {
            var meetingItemStatus = new MeetingItemStatus();
            var meetingItem = await _meetingItemRepository.GetMeetingItemByIdAsync(meetingItemStatusDto.Id);
            if (meetingItem == null) return null;

            meetingItemStatus.MeetingItem = meetingItem;
            meetingItemStatus.Status = meetingItemStatusDto.Status;
            meetingItemStatus.AddedDate = DateTime.Now;

            var meetingStatusResult = await _meetingItemStatusRepository.AddMeetingItemStatusAsync(meetingItemStatus);
            if (meetingStatusResult) return meetingItemStatus;

            return null;
        }
    }
}
