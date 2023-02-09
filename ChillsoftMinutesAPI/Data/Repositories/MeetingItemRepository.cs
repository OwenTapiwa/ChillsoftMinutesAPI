using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Data.Repositories
{
    public class MeetingItemRepository : IMeetingItemRepository
    {
        private readonly DataContext _context;
        public MeetingItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<MeetingItem>> GetAllMeetingItemsAsync()
        {
            return await _context.MeetingItems
                .Include(x => x.MeetingItemStatus)
                .ToListAsync();
        }
        public async Task<bool> AddMeetingItemAsync(MeetingItem meetingItem)
        {
            _context.Entry(meetingItem).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateMeetingItemAsync(MeetingItem meetingItem)
        {
            _context.Entry(meetingItem).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<MeetingItem> GetMeetingItemByIdAsync(string id)
        {
            return await _context.MeetingItems
                .Where(x => x.Id.ToString() == id.Trim())
                .Include(x => x.MeetingItemStatus)
                .FirstOrDefaultAsync();
        }

    }
}
