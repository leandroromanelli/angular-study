using ChatService.Contexts;
using ChatService.Interfaces.Repositories;
using ChatService.Interfaces.UnitiesOfWork;
using ChatService.Repositories;

namespace ChatService.UnitiesOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        private IDummyDataRepository _dummyDataRepository;
        public IDummyDataRepository DummyDataRepository { get { _dummyDataRepository ??= new DummyDataRepository(_context); return _dummyDataRepository; } }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository { get { _userRepository ??= new UserRepository(_context); return _userRepository; } }

        private IRoomRepository _roomRepository;
        public IRoomRepository RoomRepository { get { _roomRepository ??= new RoomRepository(_context); return _roomRepository; } }

        private IUserRoomRepository _userRoomRepository;
        public IUserRoomRepository UserRoomRepository { get { _userRoomRepository ??= new UserRoomRepository(_context); return _userRoomRepository; } }

        public async Task Save(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
