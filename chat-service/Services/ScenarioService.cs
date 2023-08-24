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
    }
}
