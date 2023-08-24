using MeetingService.Entities;
using MeetingService.Interfaces.Services;
using MeetingService.Interfaces.UnitiesOfWork;

namespace MeetingService.Services
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RoleRepository)
        {
        }

        public async Task<IEnumerable<Role>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoleRepository.GetByScenario(tenant, scenarioId, cancellationToken);
        }
    }
}
