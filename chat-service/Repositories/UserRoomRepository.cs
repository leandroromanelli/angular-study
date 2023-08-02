using ChatService.Contexts;
using ChatService.Entities;
using ChatService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories
{
    public class UserRoomRepository : Repository<UserRoom>, IUserRoomRepository
    {
        public UserRoomRepository(Context context) : base(context)
        {
        }

        public async Task<UserRoom> Get(Guid userId, Guid roomId, CancellationToken cancellationToken)
        {
            return await _context.UserRooms.FirstOrDefaultAsync(x => x.UserId == userId && x.RoomId == roomId, cancellationToken);
        }
    }
}
