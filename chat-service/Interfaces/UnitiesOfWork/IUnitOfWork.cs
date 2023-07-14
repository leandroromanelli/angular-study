using ChatService.Interfaces.Repositories;

namespace ChatService.Interfaces.UnitiesOfWork
{
    public interface IUnitOfWork
    {
        IDummyDataRepository DummyDataRepository { get; }
        IUserRepository UserRepository { get; }
        IRoomRepository RoomRepository { get; }
        IUserRoomRepository UserRoomRepository { get; }
        
        Task Save(CancellationToken cancellationToken);
    }
}
