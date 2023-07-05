using System;
using System.Collections.Generic;
using chat_service.Models;
using Microsoft.EntityFrameworkCore;

namespace chat_service.Contexts;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DummyData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DummyDat__3214EC271AD1CD48");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmailId)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.PhoneNumber).IsUnicode(false);
            entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
