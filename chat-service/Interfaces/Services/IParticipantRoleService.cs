using MeetingService.Entities;

namespace MeetingService.Interfaces.Services
{
    public interface IParticipantRoleService : IService<ParticipantRole>
    {
        Task<IEnumerable<ParticipantRole>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken);
        Task<ParticipantRole> GetComplete(string tenant, Guid id, CancellationToken cancellationToken);
    }
}
