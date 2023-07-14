using ChatService.Contexts;
using ChatService.Entities;
using ChatService.Interfaces.Repositories;

namespace ChatService.Repositories
{
    public class UserRoomRepository : Repository<UserRoom>, IUserRoomRepository
    {
        public UserRoomRepository(Context context) : base(context)
        {
        }
    }
}
