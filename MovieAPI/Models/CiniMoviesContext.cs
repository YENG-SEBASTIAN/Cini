using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Models;

public partial class CiniMoviesContext : DbContext
{
    public CiniMoviesContext()
    {
    }

    public CiniMoviesContext(DbContextOptions<CiniMoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CiniMovie> CiniMovies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CiniMovie>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.Property(e => e.Genre).IsRequired();
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
