using MeetingService.Entities;

namespace MeetingService.Interfaces.Services
{
    public interface IService<T> where T : EntityBase
    {
        Task<IEnumerable<T>> List(CancellationToken cancellationToken);
        Task<T> Get(Guid id, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
        Task<T> Add(T obj, CancellationToken cancellationToken);
        Task<T> Update(T obj, Guid id, CancellationToken cancellationToken);
    }
}
