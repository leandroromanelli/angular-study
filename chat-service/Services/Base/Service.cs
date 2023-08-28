using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;
using MeetingService.Interfaces.Services;
using MeetingService.Interfaces.UnitiesOfWork;

namespace MeetingService.Services
{
    public abstract class Service<T> : IService<T> where T : EntityBase
    {
        internal readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<T>> List(string tenant, CancellationToken cancellationToken)
        {
            return await _repository.List(tenant, cancellationToken);
        }

        public async Task<T> Get(string tenant, Guid id, CancellationToken cancellationToken)
        {
            return await _repository.Get(tenant, id, cancellationToken);
        }

        public async Task Delete(string tenant, Guid id, CancellationToken cancellationToken)
        {
            var obj = await _repository.Get(tenant, id, cancellationToken) ?? throw new ArgumentNullException(nameof(id));
            _repository.Delete(tenant, obj);
            await _unitOfWork.Save(cancellationToken);
        }

        public abstract Task Add(string tenant, T obj, CancellationToken cancellationToken);

        public async Task Update(string tenant, T obj, Guid id, CancellationToken cancellationToken)
        {
            _ = await _repository.Get(tenant, id, cancellationToken) ?? throw new ArgumentNullException(nameof(id));
            obj.Id = id;

            _repository.Update(tenant, obj);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
