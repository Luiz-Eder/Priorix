using Microsoft.EntityFrameworkCore;
using Priorix.Core.Entities;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<PriorizationMetrics> PriorizationMetrics { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relação User → Task
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.ResponsibleUser)
                .HasForeignKey(t => t.ResponsibleUserId);

            // Relação Status → Task
            modelBuilder.Entity<Statuses>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Statuses>()
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Statuses)
                .HasForeignKey(t => t.StatusId);

            // Relação Task → Metrics / History
            modelBuilder.Entity<TaskEntity>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.PriorizationMetrics)
                .WithOne(pm => pm.Task)
                .HasForeignKey(pm => pm.TaskId);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.TaskHistories)
                .WithOne(th => th.Task)
                .HasForeignKey(th => th.TaskId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
