using ChatService.Entities;

namespace ChatService.Interfaces.Repositories
{
    public interface IUserRoomRepository : IRepository<UserRoom>
    {
        Task<UserRoom> Get(Guid userId, Guid roomId, CancellationToken cancellationToken);
    }
}
