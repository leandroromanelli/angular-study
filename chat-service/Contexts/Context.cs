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

    public virtual DbSet<Scenario> Scenario { get; set; }
    public virtual DbSet<ParticipantRole> ParticipantRole { get; set; }
    public virtual DbSet<Participant> Participant { get; set; }
    public virtual DbSet<Room> Room { get; set; }
    public virtual DbSet<Message> Message { get; set; }
}
