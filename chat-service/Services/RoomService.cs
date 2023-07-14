using ChatService.Entities;
using ChatService.Interfaces.Services;
using ChatService.Interfaces.UnitiesOfWork;
using OpenTokSDK;

namespace ChatService.Services
{
    public class RoomService : Service<Room>, IRoomService
    {
        private readonly OpenTok _openTok;

        public RoomService(IUnitOfWork unitOfWork,
                           IConfiguration configuration) : base(unitOfWork, unitOfWork.RoomRepository)
        {
            _openTok = new OpenTok(int.Parse(configuration["ApiKey"]), configuration["ApiSecret"]);
        }

        public async Task<Room> AddRoom(Room room, CancellationToken cancellationToken)
        {
            var isInsert = false;

            var dbRoom = await Find(room.Name, cancellationToken);

            if (dbRoom == null)
            {
                isInsert = true;
                dbRoom = room;

                var session = _openTok.CreateSession();

                room.SessionId = session.Id;
            }

            foreach (var user in room.Users)
            {
                var dbUser = await _unitOfWork.UserRepository.Find(user.Name, cancellationToken);

                if (dbUser == null)
                {
                    throw new NullReferenceException("User not found.");
                }

                if (!isInsert && dbRoom.UserRooms.Any(r => r.UserId == dbUser.Id))
                    continue;

                dbUser.UserRooms = new List<UserRoom>();

                var role = (Role)((int)user.Role.Value);

                var userRoom = new UserRoom(dbUser.Id, dbRoom.Id, _openTok.GenerateToken(dbRoom.SessionId, role), role)
                {
                    User = null,
                    Room = null
                };

                await _unitOfWork.UserRoomRepository.Add(userRoom, cancellationToken);
                await _unitOfWork.Save(cancellationToken);
            }

            dbRoom.UserRooms = new List<UserRoom>();

            if (isInsert)
                await _unitOfWork.RoomRepository.Add(dbRoom, cancellationToken);
            else
                await _unitOfWork.RoomRepository.Update(dbRoom, cancellationToken);

            await _unitOfWork.Save(cancellationToken);

            return await Find(room.Name, cancellationToken);
        }

        public async Task<Room> Find(string name, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoomRepository.GetComplete(name, cancellationToken);
        }
    }
}
