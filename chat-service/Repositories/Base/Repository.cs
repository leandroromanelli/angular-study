using MeetingService.Contexts;
using MeetingService.Entities;
using MeetingService.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public T Add(string tenant, T entity)
        {
            entity.Tenant = tenant;
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(string tenant, T entity)
        {
            entity.Tenant = tenant;
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> List(string tenant, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().Where(t => t.Tenant == tenant).ToListAsync(cancellationToken);
        }

        public async Task<T> Get(string tenant, Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().Where(t => t.Tenant == tenant && t.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public T Update(string tenant, T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);

            return entity;
        }
    }
}
