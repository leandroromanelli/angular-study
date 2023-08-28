using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetByName(string tenant, Guid scenarioId, string name, CancellationToken cancellationToken);
        Task<Room> GetComplete(string tenant, Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Room>> ListComplete(string tenant, CancellationToken cancellationToken);
    }
}
