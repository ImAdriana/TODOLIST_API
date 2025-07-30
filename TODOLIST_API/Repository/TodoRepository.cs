using Microsoft.EntityFrameworkCore;
using TODOLIST_API.Context;
using TODOLIST_API.Models;

namespace TODOLIST_API.Repository
{
    public class TodoRepository : ITodoRepository<TodoItem>
    {
        private AppDbContext _context;
        public TodoRepository( AppDbContext context) { 
            _context = context;
        }
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _context.TodoItems.FindAsync(id);

        }
        public async Task<IEnumerable<TodoItem>> IsTaskCompleted(bool isCompleted)
        {
            return await _context.TodoItems.Where(t => t.isCompleted == isCompleted).ToListAsync();
        }
        public async Task Add(TodoItem entity)
        
            => await _context.TodoItems.AddAsync(entity);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public void Update(TodoItem entity)
        {
           _context.TodoItems.Attach(entity);
            _context.TodoItems.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TodoItem entity)

            => _context.TodoItems.Remove(entity);

        
    }
}
