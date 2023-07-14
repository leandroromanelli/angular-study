using ChatService.Entities;

namespace ChatService.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Find(string name, CancellationToken cancellationToken);
    }
}
