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

        public async Task<IEnumerable<T>> List(CancellationToken cancellationToken)
        {
            return await _repository.List(cancellationToken);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.Get(id, cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _repository.Get(id, cancellationToken) ?? throw new ArgumentNullException(nameof(id));
            _repository.Delete(obj);
            await _unitOfWork.Save(cancellationToken);
        }

        public async Task<T> Add(T obj, CancellationToken cancellationToken)
        {
            var dbObj = await _repository.Get(obj.Id, cancellationToken);

            if (dbObj != null)
                throw new ArgumentException("entry already exists");

            _repository.Add(obj);
            await _unitOfWork.Save(cancellationToken);

            return obj;
        }

        public async Task<T> Update(T obj, Guid id, CancellationToken cancellationToken)
        {
            _ = await _repository.Get(id, cancellationToken) ?? throw new ArgumentNullException(nameof(id));
            obj.Id = id;

            _repository.Update(obj);
            await _unitOfWork.Save(cancellationToken);

            return obj;
        }
    }
}
