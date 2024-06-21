using TrabalhoJef.ModelTask;
using Microsoft.EntityFrameworkCore;

namespace TrabalhoJef.BancoTask
{
    public class DbContextTask : DbContext
    {
        public DbContextTask(DbContextOptions<DbContextTask> options) : base(options) { }
        public DbSet<TasksModel> TasksModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TasksModel>().Property(t => t.State);

            base.OnModelCreating(modelBuilder);
        }
    }
}