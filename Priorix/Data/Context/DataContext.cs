using Microsoft.EntityFrameworkCore;
using Priorix.Core.Entities;
using Priorix.Core.Services;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<PriorizationMetrics> PriorizationMetrics { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- User ---
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.ResponsibleUser)
                .HasForeignKey(t => t.ResponsibleUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Status ---
            modelBuilder.Entity<Status>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Task ---
            modelBuilder.Entity<TaskEntity>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.PriorizationMetrics)
                .WithOne(pm => pm.Task)
                .HasForeignKey(pm => pm.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.TaskHistories)
                .WithOne(th => th.Task)
                .HasForeignKey(th => th.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
