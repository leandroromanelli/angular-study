using ChatService.Entities;
using ChatService.Interfaces.Repositories;
using ChatService.Interfaces.Services;
using ChatService.Interfaces.UnitiesOfWork;

namespace ChatService.Services
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
            var obj = await _repository.Get(id, cancellationToken);

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            await _repository.Delete(obj, cancellationToken);
            await _unitOfWork.Save(cancellationToken);
        }

        public async Task<T> Add(T obj, CancellationToken cancellationToken)
        {
            var dbObj = await _repository.Get(obj.Id, cancellationToken);

            if (dbObj != null)
                throw new ArgumentNullException(nameof(obj));

            await _repository.Add(obj, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            return obj;
        }

        public async Task<T> Update(T obj, Guid id, CancellationToken cancellationToken)
        {
            var dbObj = await _repository.Get(id, cancellationToken);

            if (dbObj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.Id = id;

            await _repository.Update(obj, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            return obj;
        }
    }
}
