using AutoMapper;
using ChillsoftMinutesAPI.DTOs;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Data.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MeetingRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Meeting>> GetAllMeetingsAsync()
        {
            return await _context.Meetings
                .Include(x => x.MeetingType)
                .Include(x => x.MinutesTaker)
                .ToListAsync();
        }
        public async Task<Meeting> GetMeetingsByIdAsync(int meetingId)
        {
            return await _context.Meetings
                .Where(x => x.Id == meetingId)
                .Include(x => x.MeetingType)
                .Include(x => x.MinutesTaker)
                .Include(x => x.MeetingItem)
                .FirstOrDefaultAsync();
        }

        public async Task<Meeting> GetMeetingsByMeetingIdAsync(string meetingId)
        {
            return await _context.Meetings
                .Where(x => x.MeetingId == meetingId)
                .Include(x => x.MeetingType)
                .Include(x => x.MinutesTaker)
                .Include(x => x.MeetingItem)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MeetingResponseDto>> GetMeetingsByIdDtoAsync(int meetingId)
        {
            var meeting = await _context.Meetings
                .Where(x => x.Id == meetingId)
                .Include(x => x.MeetingType)
                .Include(x => x.MinutesTaker)
                .Include(x => x.MeetingItem)
                .ToListAsync();

            List<Meeting> copy = meeting.ToList();
            var list = _mapper.Map<List<Meeting>, List<MeetingResponseDto>>(copy);
            return list;

        }

        public async Task<bool> AddMeetingAsync(Meeting meeting)
        {
            _context.Entry(meeting).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateMeetingAsync(Meeting meeting)
        {
            _context.Entry(meeting).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Meeting> PreviousMeeting(MeetingType meetingType)
        {
            return await _context.Meetings.AsNoTracking().Where(x => x.MeetingType == meetingType).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
