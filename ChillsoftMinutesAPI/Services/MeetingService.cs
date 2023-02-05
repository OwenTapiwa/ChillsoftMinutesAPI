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

        private readonly IMapper _mapper;
        public MeetingService(IMeetingRepository meetingRepository, IMeetingTypeRepository meetingTypeRepository, IMapper mapper, IUsersRepository usersRepository) 
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _meetingTypeRepository = meetingTypeRepository; 
            _usersRepository = usersRepository;
        }

        public async Task<Meeting> CreateMeeting(MeetingDto meetingDto)
        {
            string newMeetingId = "";
            var meeting = new Meeting();    
            var meetingType = await _meetingTypeRepository.GetMeetingTypeByName(meetingDto.MeetingType);
            if (meetingType == null) return null;

            var users = await _usersRepository.GetUserByUsernameAsync(meetingDto.MinutesTaker);
            if (users == null) return null;

            var previousMeeting = await _meetingRepository.PreviousMeeting(meetingType.Id);
            if(previousMeeting != null) 
            {
                 newMeetingId = meetingType.PreFix + (previousMeeting.Id + 1).ToString();
            }
            else
            {
                newMeetingId = meetingType.PreFix + "1";
            }
            meeting.MeetingType = meetingType;
            meeting.MinutesTaker = users;
            meeting.MeetingId = newMeetingId;
            meeting.DateHeld = meetingDto.DateHeld;

            var result = await _meetingRepository.AddMeetingAsync(meeting);
            if (result) return meeting;

            return null;
        }
        public async Task<Meeting> UpdateMeeting(MeetingDto meetingDto)
        {
            var meeting = new Meeting();
            var meetingType = await _meetingTypeRepository.GetMeetingTypeByName(meetingDto.MeetingType);
            if (meetingType == null) return null;
            var previousMeeting = await _meetingRepository.GetMeetingById(meetingDto.MeetingId);

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

    }
}
