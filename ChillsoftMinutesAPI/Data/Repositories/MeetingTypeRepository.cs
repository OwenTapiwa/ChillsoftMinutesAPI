using AutoMapper;
using ChillsoftMinutesAPI.Entities;
using ChillsoftMinutesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChillsoftMinutesAPI.Data.Repositories
{
    public class MeetingTypeRepository : IMeetingTypeRepository
    {
        private readonly DataContext _context;
        public MeetingTypeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<MeetingType>> GetMeetingTypesAsync()
        {
            return await _context.MeetingTypes.ToListAsync();
        }
        public async Task<bool> AddTypeAsync(MeetingType meetingType)
        {
            _context.Entry(meetingType).State = EntityState.Added;
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<MeetingType> GetMeetingTypeByName(string name)
        {
            return await _context.MeetingTypes.Where(x => x.Name == name.Trim()).FirstOrDefaultAsync();
        }
        public async Task<bool> RemoveTypeAsync(MeetingType meetingType)
        {
            _context.Entry(meetingType).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;

        }
        public bool MeetingTypeExists(string meetingType)
        {
            return _context.MeetingTypes.Any(o => o.Name.ToLower().Trim() == meetingType);
        }
    }
}
