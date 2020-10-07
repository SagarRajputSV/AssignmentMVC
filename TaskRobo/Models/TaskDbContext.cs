using System.Data.Entity;

namespace TaskRobo.Models
{
    //This class represents the DbContext class for Entity Framework to communicate with database
    // in code-first approach.
    public class TaskDbContext:DbContext
    {
        public TaskDbContext():base("CrudConnection")
        {
            Database.SetInitializer<TaskDbContext>(null);
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}
