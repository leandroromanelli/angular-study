using MeetingService.Entities;
using MeetingService.Interfaces.Services;
using MeetingService.Interfaces.UnitiesOfWork;

namespace MeetingService.Services
{
    public class ScenarioService : Service<Scenario>, IScenarioService
    {
        public ScenarioService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ScenarioRepository)
        {
        }

        public override async Task Add(string tenant, Scenario obj, CancellationToken cancellationToken)
        {
            var dbObj = await _unitOfWork.ScenarioRepository.GetByName(tenant, obj.Name, cancellationToken);

            if (dbObj != null)
                throw new ArgumentException("entry already exists");

            _unitOfWork.ScenarioRepository.Add(tenant, obj);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
