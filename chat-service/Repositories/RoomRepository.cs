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

        public async Task<Room> GetByName(string tenant, Guid scenarioId, string name, CancellationToken cancellationToken)
        { 
            return await _context.Room
                                 .Where(x => x.Tenant == tenant && x.ScenarioId == scenarioId && x.Name == name)
                                 .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Room> GetComplete(string tenant, Guid id, CancellationToken cancellationToken)
        {
            return await _context.Room
                                 .Where(r => r.Tenant == tenant && r.Id == id)
                                 .Include("Scenario")
                                 .Include("Participants")
                                 .Include("Participants.Role")
                                 .Include("Messages")
                                 .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Room>> ListComplete(string tenant, CancellationToken cancellationToken)
        {
            return await _context.Room
                                 .Where(r => r.Tenant == tenant)
                                 .Include("Scenario")
                                 .Include("Participants")
                                 .Include("Participants.Role")
                                 .Include("Messages")
                                 .ToListAsync(cancellationToken);
        }
    }
}
