using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IParticipantRoleRepository : IRepository<ParticipantRole>
    {
        Task<IEnumerable<ParticipantRole>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken);
        Task<ParticipantRole> GetByName(string tenant, Guid scenarioId, string name,  CancellationToken cancellationToken);
        Task<ParticipantRole> GetComplete(string tenant, Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<ParticipantRole>> ListComplete(string tenant, CancellationToken cancellationToken);
    }
}
