﻿using MeetingService.Entities;

namespace MeetingService.Interfaces.Services
{
    public interface IService<T> where T : EntityBase
    {
        Task<IEnumerable<T>> List(string tenant, CancellationToken cancellationToken);
        Task<T> Get(string tenant, Guid id, CancellationToken cancellationToken);
        Task Delete(string tenant, Guid id, CancellationToken cancellationToken);
        Task Add(string tenant, T obj, CancellationToken cancellationToken);
        Task Update(string tenant, T obj, Guid id, CancellationToken cancellationToken);
    }
}
