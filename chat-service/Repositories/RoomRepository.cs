using MeetingService.Contexts;
using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(Context context) : base(context)
        {
        }

        public async Task<Room> GetComplete(string tenant, Guid id, CancellationToken cancellationToken)
        {

            return await _context.Room
                                 .Where(r => r.Tenant == tenant && r.Id == id)
                                 .Include(r => r.Participants)
                                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
