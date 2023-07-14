using ChatService.Entities;

namespace ChatService.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetComplete(string name, CancellationToken cancellation);
    }
}
