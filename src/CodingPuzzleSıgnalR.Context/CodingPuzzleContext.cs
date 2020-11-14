using CodingPuzzleSıgnalR.ApplicationContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodingPuzzleSıgnalR.Context
{
    public class CodingPuzzleContext:DbContext
    {
        public CodingPuzzleContext()
        {
        }

        public CodingPuzzleContext(DbContextOptions<CodingPuzzleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<RefType> RefType { get; set; }
        public virtual DbSet<RefValue> RefValue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=User123!!;Host=localhost;Port=5432;Database=Coding.Puzzle;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
