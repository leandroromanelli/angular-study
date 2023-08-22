using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> List(CancellationToken cancellationToken);
        Task<T> Get(Guid id, CancellationToken cancellationToken);
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);
    }
}
