using ChatService.Contexts;
using ChatService.Entities;
using ChatService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<User> Find(string name, CancellationToken cancellationToken)
        {
            return await _context.Users
                                 .Where(x => x.Name == name)
                                 .Include("UserRooms")
                                 .Include("UserRooms.Room")
                                 .FirstOrDefaultAsync(cancellationToken);
        }

        public new async Task<IEnumerable<User>> List(CancellationToken cancellationToken)
        {
            return await _context.Users
                                 .Include("UserRooms")
                                 .Include("UserRooms.Room")
                                 .ToListAsync(cancellationToken);
        }
    }
}
