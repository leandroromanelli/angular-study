using MeetingService.Entities;
using MeetingService.Interfaces.Services;
using MeetingService.Interfaces.UnitiesOfWork;
using OpenTokSDK;

namespace MeetingService.Services
{
    public class RoomService : Service<Room>, IRoomService
    {
        private readonly OpenTok _openTok;

        public RoomService(IUnitOfWork unitOfWork,
                           IConfiguration configuration) : base(unitOfWork, unitOfWork.RoomRepository)
        {
            _openTok = new OpenTok(int.Parse(configuration["ApiKey"]), configuration["ApiSecret"]);
        }

        public async Task<Room> AddRoom(string tenant, Room room, CancellationToken cancellationToken)
        {
            var dbRoom = await Get(tenant, room.Id, cancellationToken);

            var isInsert = false;

            if (dbRoom == null)
            {
                dbRoom = room;
                isInsert = true;
            }

            dbRoom.SessionId = _openTok.CreateSession().Id;
            dbRoom.Tenant = tenant;

            dbRoom = GenerateTokens(dbRoom);

            if (isInsert)
                _unitOfWork.RoomRepository.Add(tenant, dbRoom);
            else
                _unitOfWork.RoomRepository.Update(tenant, dbRoom);

            await _unitOfWork.Save(cancellationToken);

            return await Get(tenant, room.Id, cancellationToken);
        }

        private Room GenerateTokens(Room room)
        {
            room ??= new Room();

            foreach (var participant in room.Participants)
            {
                if (!string.IsNullOrWhiteSpace(participant.Token))
                    continue;

                participant.Token = _openTok.GenerateToken(room.SessionId, participant.Role.VonageRole);
            }

            return room;
        }
    }
}
