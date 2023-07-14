using ChatService.Contexts;
using ChatService.Entities;
using ChatService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> List(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<T> Update(T entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);

            return entity;
        }
    }
}
