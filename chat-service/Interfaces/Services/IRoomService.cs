using ChatService.Entities;

namespace ChatService.Interfaces.Services
{
    public interface IRoomService : IService<Room>
    {
        Task<Room> AddRoom(Room room, CancellationToken cancellationToken);
        Task<Room> Find(string name, CancellationToken cancellationToken);
    }
}
