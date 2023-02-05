using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Data.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly DataContext _context;
        public MeetingRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Meeting>> GetAllMeetingsAsync()
        {
            return await _context.Meetings.ToListAsync();
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

        public async Task<Meeting> GetMeetingById(string id)
        {
            return await _context.Meetings.Where(x => x.MeetingId == id.Trim()).FirstOrDefaultAsync();
        }

        public async Task<Meeting> PreviousMeeting(int meetingId)
        {
            return await _context.Meetings.AsNoTracking().Where(x => x.Id == meetingId).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
