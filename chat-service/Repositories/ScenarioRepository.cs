using MeetingService.Contexts;
using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.Repositories
{
    public class ScenarioRepository : Repository<Scenario>, IScenarioRepository
    {
        public ScenarioRepository(Context context) : base(context)
        {
        }


        public async Task<Scenario> GetByName(string tenant, string name, CancellationToken cancellationToken)
        {
            return await _context.Scenario
                                 .Where(x => x.Tenant == tenant && x.Name == name)
                                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
