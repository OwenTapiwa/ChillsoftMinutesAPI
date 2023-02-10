using AutoMapper;
using ChillsoftMinutesAPI.Data.Repositories;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;

namespace ChillsoftMinutesAPI.Services
{
    public class MeetingItemService : IMeetingItemService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMeetingItemRepository _meetingItemRepository;
        private readonly IMeetingItemStatusRepository _meetingItemStatusRepository;
        private readonly IUsersRepository _usersRepository;

        private readonly IMapper _mapper;
        public MeetingItemService(IMeetingRepository meetingRepository, IMeetingItemRepository meetingItemRepository, IMapper mapper, IUsersRepository usersRepository, IMeetingItemStatusRepository meetingItemStatusRepository)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _meetingItemRepository = meetingItemRepository;
            _usersRepository = usersRepository;
            _meetingItemStatusRepository = meetingItemStatusRepository;
        }

        public async Task<MeetingItem> CreateMeetingItem(MeetingItemDto meetingItemDto)
        {
            string newMeetingId = "";
            var meetingItem = new MeetingItem();
            var meetingItemStatus = new MeetingItemStatus();
            var meeting = await _meetingRepository.GetMeetingsByIdAsync(int.Parse(meetingItemDto.MeetingId));
            if (meeting == null) return null;

            var users = await _usersRepository.GetUserByIdAsync(meetingItemDto.PersonResponsible);
            if (users == null) return null;

            meetingItem.Action = meetingItemDto.Action;
            meetingItem.DueDate = meetingItemDto.DueDate;
            meetingItem.AddedDate = DateTime.Now;
            meetingItem.DateUpdated = DateTime.Now;
            meetingItem.PersonResponsible = users;
            meetingItem.Meeting = meeting;

            var result = await _meetingItemRepository.AddMeetingItemAsync(meetingItem);

            if (!result) return null;
            meetingItemStatus.MeetingItem = meetingItem;
            meetingItemStatus.Status = "Open";
            meetingItemStatus.AddedDate = DateTime.Now;

            var meetingStatusResult = await _meetingItemStatusRepository.AddMeetingItemStatusAsync(meetingItemStatus);
            if (meetingStatusResult) return meetingItem;

            return null;
        }

        public async Task<MeetingItem> UpdateMeetingItem(MeetingItemDto meetingItemDto)
        {
            var meeting = await _meetingRepository.GetMeetingsByIdAsync(int.Parse(meetingItemDto.MeetingId));
            if (meeting == null) return null;

            var users = await _usersRepository.GetUserByIdAsync(meetingItemDto.PersonResponsible);
            if (users == null) return null;

            var meetingItem = await _meetingItemRepository.GetMeetingItemByIdAsync(meetingItemDto.MeetingItemId);
            if (meetingItem == null) return null;

            meetingItem.Action = meetingItemDto.Action;
            meetingItem.DueDate = meetingItemDto.DueDate;
            meetingItem.DateUpdated = DateTime.Now;
            meetingItem.PersonResponsible = users;
            meetingItem.Meeting = meeting;

            var result = await _meetingItemRepository.UpdateMeetingItemAsync(meetingItem);

            if (result != null) return meetingItem;

            return null;
        }
        public async Task<IEnumerable<MeetingItemsDto>> GetMeetingItems(int meetingId)
        {
            var meetingItemsDto = new MeetingItemsDto();
            var meeting = await _meetingRepository.GetMeetingsByIdAsync(meetingId);
            if (meeting == null) return null;

          
            var meetingItems = await _meetingItemRepository.GetMeetingItemByMeeting(meeting);
            List<MeetingItem> copy = meetingItems.ToList();
            var list = _mapper.Map<List<MeetingItem>, List<MeetingItemsDto>>(copy);
            
            if (meetingItems != null) return list;

            return null;
        }

    }
}
