using ChatService.Entities;

namespace ChatService.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> List(CancellationToken cancellationToken);
        Task<T> Get(Guid id, CancellationToken cancellationToken);
        Task<T> Add(T obj, CancellationToken cancellationToken);
        Task<T> Update(T obj, CancellationToken cancellationToken);
        Task Delete(T obj, CancellationToken cancellationToken);
    }
}
