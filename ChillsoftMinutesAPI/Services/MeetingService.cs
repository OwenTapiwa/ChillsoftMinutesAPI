using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ChillsoftMinutesAPI.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMeetingTypeRepository _meetingTypeRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMeetingItemRepository _meetingItemRepository;
        private readonly IMeetingItemStatusRepository _meetingItemStatusRepository;
        private readonly IMeetingItemService _meetingItemService;
        private readonly IMapper _mapper;
        private readonly IMeetingItemStatusService _meetingItemStatusService;

        public MeetingService(IMeetingRepository meetingRepository, IMeetingTypeRepository meetingTypeRepository, IMapper mapper, IUsersRepository usersRepository, IMeetingItemRepository meetingItemRepository,IMeetingItemStatusRepository meetingItemStatusRepository, IMeetingItemService meetingItemService,IMeetingItemStatusService meetingItemStatusService) 
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _meetingTypeRepository = meetingTypeRepository; 
            _usersRepository = usersRepository;
            _meetingItemRepository = meetingItemRepository;
            _meetingItemStatusRepository = meetingItemStatusRepository;
            _meetingItemService = meetingItemService;
            _meetingItemStatusService = meetingItemStatusService;
        }

        public async Task<Meeting> CreateMeeting(MeetingDto meetingDto)
        {
            string newMeetingId = "";
            bool isFirstMeeting = false;
            var meeting = new Meeting();
            bool reassignFail = false;
            var reassignItem = new MeetingItem();
            var meetingType = await _meetingTypeRepository.GetMeetingTypeByName(meetingDto.MeetingType);
            if (meetingType == null) return null;

            var users = await _usersRepository.GetUserByUsernameAsync(meetingDto.MinutesTaker);
            if (users == null) return null;

            var previousMeeting = await _meetingRepository.PreviousMeeting(meetingType);
            if(previousMeeting == null) 
            {
                newMeetingId = meetingType.PreFix + '-' + "1";
                isFirstMeeting = true;
            }
            else
            {
                var prev = previousMeeting.MeetingId.Trim().Split('-');
                int prevInt = int.Parse(prev[1]);
                newMeetingId = meetingType.PreFix + '-' + (prevInt + 1).ToString();
            }
            meeting.MeetingType = meetingType;
            meeting.MinutesTaker = users;
            meeting.MeetingId = newMeetingId;
            meeting.DateHeld = meetingDto.DateHeld;

            var result = await _meetingRepository.AddMeetingAsync(meeting);
            if (!result) return null;
            if (!isFirstMeeting)
            {
                //check if all items are completed
                //get mmeting items
                
                var meetingItems = await _meetingItemRepository.GetMeetingItemByMeeting(previousMeeting);
                if (meetingItems == null) return null;
                //loop through meetingItems
                if(meetingItems.Count() > 0)
                {
                    for (int i = 0; i < meetingItems.Count(); i++)
                    {
                        // get meeting item status not complete
                        var meetingItemStatus = await _meetingItemStatusRepository.GetNotCompleMeetingItemStatusAsync(meetingItems.ElementAt(i));
                        if (meetingItemStatus != null)
                        {
                            if (meetingItemStatus.Status.ToLower() != "completed")
                            {
                                //change status to carried forward
                                //get meetiItemstatus
                                var meetingItemNewStatus = new MeetingItemStatusDto();
                                meetingItemNewStatus.Status = "Moved";
                                meetingItemNewStatus.Id = meetingItemStatus.MeetingItem.Id.ToString();
                                var meetingStatusResult = await _meetingItemStatusService.CreateMeetingItemStatus(meetingItemNewStatus);
                                if(meetingStatusResult == null) return null;

                                //create new meeting item 
                                var meetingItemDto = new MeetingItemDto();

                                meetingItemDto.MeetingId = newMeetingId;
                                meetingItemDto.PersonResponsible = meetingItems.ElementAt(i).PersonResponsible.UserName;
                                meetingItemDto.Action = meetingItems.ElementAt(i).Action;
                                meetingItemDto.DueDate = meetingItems.ElementAt(i).DueDate;
                                meetingItemDto.MeetingItemId = meetingItems.ElementAt(i).Id.ToString();

                                var meetingItemAdd = await _meetingItemService.CreateMeetingItem(meetingItemDto);
                                if(meetingItemAdd == null) reassignFail = true;

                            }

                        }
                    }
                }
              

            }
            if (!reassignFail) return meeting;

            return null;
        }
        public async Task<Meeting> UpdateMeeting(MeetingDto meetingDto)
        {
            var meeting = new Meeting();
            var meetingType = await _meetingTypeRepository.GetMeetingTypeByName(meetingDto.MeetingType);
            if (meetingType == null) return null;
            var previousMeeting = await _meetingRepository.GetMeetingsByIdAsync(int.Parse(meetingDto.MeetingId));

            if (previousMeeting != null)
            {
                var users = await _usersRepository.GetUserByUsernameAsync(meetingDto.MinutesTaker);
                if (users == null) return null;
                meeting.MeetingId = previousMeeting.MeetingId;
                meeting.MeetingType = meetingType;
                meeting.MinutesTaker = users;
                meeting.DateHeld = meetingDto.DateHeld;

                var result = await _meetingRepository.UpdateMeetingAsync(meeting);
                if (result) return meeting;

            }

            return null;
        }

        public async Task<IEnumerable<MeetingResponseDto>> GetMeeting(int meetingId)
        {
            var meeting = await _meetingRepository.GetMeetingsByIdDtoAsync(meetingId);
            if (meeting != null) return meeting;

            return null;
        }

    }
}
