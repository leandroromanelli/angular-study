using MeetingService.Contexts;
using MeetingService.Interfaces.Repositories;
using MeetingService.Interfaces.UnitiesOfWork;
using MeetingService.Repositories;

namespace MeetingService.UnitiesOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        private IRoomRepository _roomRepository;
        public IRoomRepository RoomRepository { get { _roomRepository ??= new RoomRepository(_context); return _roomRepository; } }

        public async Task Save(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
