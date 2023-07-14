using ChatService.Entities;
using ChatService.Interfaces.Services;
using ChatService.Interfaces.UnitiesOfWork;

namespace ChatService.Services
{
    public class DummyDataService : Service<DummyData>, IDummyDataService
    {
        public DummyDataService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DummyDataRepository)
        {
        }
    }
}
