using MeetingService.Interfaces.Repositories;

namespace MeetingService.Interfaces.UnitiesOfWork
{
    public interface IUnitOfWork
    {
        IRoomRepository RoomRepository { get; }
        
        Task Save(CancellationToken cancellationToken);
    }
}
