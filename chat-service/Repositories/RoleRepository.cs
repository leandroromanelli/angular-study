using MeetingService.Contexts;
using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken)
        {
            return await _context.Role
                                 .Where(x => x.Tenant == tenant && x.ScenarioId == scenarioId)
                                 .ToListAsync(cancellationToken);
        }
    }
}
