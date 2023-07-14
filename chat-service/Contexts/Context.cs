using ChatService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Contexts;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DummyData> DummyData { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<UserRoom> UserRooms { get; set; }
    public virtual DbSet<User> Users { get; set; }
}
