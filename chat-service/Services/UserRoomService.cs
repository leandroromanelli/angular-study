using ChatService.Entities;
using ChatService.Interfaces.Services;
using ChatService.Interfaces.UnitiesOfWork;

namespace ChatService.Services
{
    public class UserRoomService : Service<UserRoom>, IUserRoomService
    {
        public UserRoomService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UserRoomRepository)
        {
        }
    }
}
