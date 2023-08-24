using MeetingService.Interfaces.Repositories;

namespace MeetingService.Interfaces.UnitiesOfWork
{
    public interface IUnitOfWork
    {
        IRoomRepository RoomRepository { get; }
        IRoleRepository RoleRepository { get; }
        IScenarioRepository ScenarioRepository { get; }
        
        Task Save(CancellationToken cancellationToken);
    }
}
