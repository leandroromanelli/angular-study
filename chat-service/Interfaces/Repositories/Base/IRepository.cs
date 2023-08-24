using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> List(string tenant, CancellationToken cancellationToken);
        Task<T> Get(string tenant, Guid id, CancellationToken cancellationToken);
        T Add(string tenant, T obj);
        T Update(string tenant, T obj);
        void Delete(string tenant, T obj);
    }
}
