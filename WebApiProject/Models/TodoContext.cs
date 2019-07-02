using Microsoft.EntityFrameworkCore;


namespace WebApiProject.Models
{
    public class TodoContext : DbContext
    {
        /// <inheritdoc />
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
