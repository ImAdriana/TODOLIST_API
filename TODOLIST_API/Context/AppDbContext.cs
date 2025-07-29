using Microsoft.EntityFrameworkCore;
using TODOLIST_API.Models;

namespace TODOLIST_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
