using MeetingService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.Contexts;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Participant> Users { get; set; }
}
