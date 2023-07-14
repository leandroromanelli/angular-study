using ChatService.Entities;
using ChatService.Interfaces.Services;
using ChatService.Interfaces.UnitiesOfWork;

namespace ChatService.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UserRepository)
        {
        }
    }
}
