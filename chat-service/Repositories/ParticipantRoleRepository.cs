using MeetingService.Contexts;
using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.Repositories
{
    public class ParticipantRoleRepository : Repository<ParticipantRole>, IParticipantRoleRepository
    {
        public ParticipantRoleRepository(Context context) : base(context)
        {
        }

        public async Task<ParticipantRole> GetByName(string tenant, Guid scenarioId, string name, CancellationToken cancellationToken)
        {
            return await _context.ParticipantRole
                                 .Where(x => x.Tenant == tenant && x.ScenarioId == scenarioId && x.Name == name)
                                 .Include("Scenario")
                                 .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<ParticipantRole>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken)
        {
            return await _context.ParticipantRole
                                 .Where(x => x.Tenant == tenant && x.ScenarioId == scenarioId)
                                 .ToListAsync(cancellationToken);
        }

        public async Task<ParticipantRole> GetComplete(string tenant, Guid id, CancellationToken cancellationToken)
        {
            return await _context.ParticipantRole
                                 .Where(x => x.Tenant == tenant && x.Id == id)
                                 .Include("Scenario")
                                 .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<ParticipantRole>> ListComplete(string tenant, CancellationToken cancellationToken)
        {
            return await _context.ParticipantRole
                                 .Where(x => x.Tenant == tenant)
                                 .Include("Scenario")
                                 .ToListAsync(cancellationToken);
        }
    }
}
