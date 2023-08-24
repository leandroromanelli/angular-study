using MeetingService.Contexts;
using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;

namespace MeetingService.Repositories
{
    public class ScenarioRepository : Repository<Scenario>, IScenarioRepository
    {
        public ScenarioRepository(Context context) : base(context)
        {
        }
    }
}
