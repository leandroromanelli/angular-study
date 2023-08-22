using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetComplete(string tenant, Guid id, CancellationToken cancellation);
    }
}
