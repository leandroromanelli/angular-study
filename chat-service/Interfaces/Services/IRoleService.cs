using MeetingService.Entities;

namespace MeetingService.Interfaces.Services
{
    public interface IRoleService : IService<Role>
    {
        Task<IEnumerable<Role>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken);
    }
}
