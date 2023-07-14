using ChatService.Contexts;
using ChatService.Entities;
using ChatService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(Context context) : base(context)
        {
        }

        public async Task<Room> GetComplete(string name, CancellationToken cancellationToken)
        {

            return await _context.Rooms
                                 .Where(r => r.Name == name)
                                 .Include("UserRooms")
                                 .Include("UserRooms.User")
                                 .Include("UserRooms.User.UserRooms")
                                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
