using ChatService.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Contexts;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DummyData> DummyData { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<UserRoom> UserRooms { get; set; }
    public virtual DbSet<User> Users { get; set; }
}
