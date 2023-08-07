using Microsoft.EntityFrameworkCore;
using TodoList_blazor.Shared;

namespace TodoList_blazor.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Do> Dos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Do>().HasData(new Do
            {
                DoId = 1,
                DoString = "item 1",
                Completed = false,
            });
        }


    }
}
