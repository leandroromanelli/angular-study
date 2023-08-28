using MeetingService.Entities;

namespace MeetingService.Interfaces.Services
{
    public interface IRoomService : IService<Room>
    {
        Task<Room> GetComplete(string tenant, Guid id, CancellationToken cancellationToken);
    }
}
