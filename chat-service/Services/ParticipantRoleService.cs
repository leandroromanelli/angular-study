using MeetingService.Entities;
using MeetingService.Interfaces.Services;
using MeetingService.Interfaces.UnitiesOfWork;

namespace MeetingService.Services
{
    public class ParticipantRoleService : Service<ParticipantRole>, IParticipantRoleService
    {
        public ParticipantRoleService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RoleRepository)
        {
        }

        public override async Task Add(string tenant, ParticipantRole obj, CancellationToken cancellationToken)
        {
            var dbObj = await _unitOfWork.RoleRepository.GetByName(tenant, obj.ScenarioId, obj.Name, cancellationToken);

            if (dbObj != null)
                throw new ArgumentException("entry already exists");

            _unitOfWork.RoleRepository.Add(tenant, obj);
            await _unitOfWork.Save(cancellationToken);
        }

        public async Task<ParticipantRole> GetComplete(string tenant, Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoleRepository.Get(tenant, id, cancellationToken);
        }

        public async Task<IEnumerable<ParticipantRole>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoleRepository.GetByScenario(tenant, scenarioId, cancellationToken);
        }
    }
}
