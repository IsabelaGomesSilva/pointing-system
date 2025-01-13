using Microsoft.EntityFrameworkCore;

namespace Time.Domain
{
    public class Context: DbContext
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<ProjectTask>().HasKey(t => t.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);

            modelBuilder.Entity<ProjectTask>()
                .HasOne<Project>()
                .WithMany()
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne<ProjectTask>()
                .WithMany()
                .HasForeignKey(a => a.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}