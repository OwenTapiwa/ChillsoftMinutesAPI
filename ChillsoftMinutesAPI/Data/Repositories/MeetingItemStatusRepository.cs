using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Data.Repositories
{
    public class MeetingItemStatusRepository : IMeetingItemStatusRepository
    {
        private readonly DataContext _context;
        public MeetingItemStatusRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<MeetingItemStatus>> GetMeetingItemStatusesAsync()
        {
            return await _context.MeetingItemStatuses.ToListAsync();
        }
        public async Task<bool> AddMeetingItemStatusAsync(MeetingItemStatus meetingItemStatus)
        {
            _context.Entry(meetingItemStatus).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<MeetingItemStatus> GetMeetingItemStatusByIdAsync(string id)
        {
            return await _context.MeetingItemStatuses.Where(x => x.Id.ToString() == id.Trim()).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateMeetingItemStatusAsync(MeetingItemStatus meetingItemStatus)
        {
            _context.Entry(meetingItemStatus).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
