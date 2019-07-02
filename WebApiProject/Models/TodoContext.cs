using Microsoft.EntityFrameworkCore;


namespace WebApiProject.Models
{
    public class TodoContext 
    {
        /// <inheritdoc />
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
