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

        public override async Task Add(string tenant, Room room, CancellationToken cancellationToken)
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

            dbRoom = await GenerateTokens(dbRoom, cancellationToken);

            if (isInsert)
                _unitOfWork.RoomRepository.Add(tenant, dbRoom);
            else
                _unitOfWork.RoomRepository.Update(tenant, dbRoom);

            await _unitOfWork.Save(cancellationToken);
        }

        public async Task<Room> GetComplete(string tenant, Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoomRepository.GetComplete(tenant, id, cancellationToken);
        }

        private async Task<Room> GenerateTokens(Room room, CancellationToken cancellationToken)
        {
            room ??= new Room();

            var roles = await _unitOfWork.RoleRepository.GetByScenario(room.Tenant, room.ScenarioId, cancellationToken);

            foreach (var participant in room.Participants)
            {
                if (!string.IsNullOrWhiteSpace(participant.Token))
                    continue;

                participant.Token = _openTok.GenerateToken(room.SessionId, roles.FirstOrDefault(x => x.Id == participant.RoleId).VonageRole);
            }

            return room;
        }

        public async Task CloseSession(string tenant, Guid referenceId, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetComplete(tenant, referenceId, cancellationToken);

            var streams = _openTok.ListStreams(room.SessionId).Select(x => x.Id).ToArray();
            _openTok.ForceMuteAll(room.SessionId, streams);
            foreach (var participant in room.Participants)
            {
                try
                {
                    _openTok.ForceDisconnect(room.SessionId, participant.ConnectionId);
                }
                catch { }
            }
        }
    }
}
