using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOLIST_API.Context;
using TODOLIST_API.DTO;
using TODOLIST_API.Models;

namespace TODOLIST_API.Service
{
    public class TodoService : ITodoService
    {
        AppDbContext _context;
        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoDto>> Get() =>
           await _context.TodoItems.Select(t => new TodoDto
            {
                Id = t.Id,
                Title = t.Title,
                DescriptionItem = t.DescriptionItem,
                CreatedDate = t.CreatedDate,
                EndedDate = t.EndedDate,
                isCompleted = t.isCompleted,

            }).ToListAsync();

        
        public async Task<TodoDto> GetById(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                var todoDto = new TodoDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    DescriptionItem = item.DescriptionItem,
                    CreatedDate = item.CreatedDate,
                    EndedDate = item.EndedDate,
                    isCompleted = item.isCompleted,
                };
                return todoDto;
            }
            return null;
        }
        public async Task<IEnumerable<TodoDto>> GetItemIsCompleted(bool isCompleted)
        {
            var item = await _context.TodoItems
                .Where(t => t.isCompleted == isCompleted)
                .Select(t => new TodoDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    DescriptionItem = t.DescriptionItem,
                    CreatedDate = t.CreatedDate,
                    EndedDate = t.EndedDate,
                    isCompleted = t.isCompleted
                })
                .ToListAsync();
            return item != null ? item : null;

        }

        public async Task<TodoDto> InsertItem(TodoInsertDto todoInsertDto)
        {
            var item = new TodoItem
            {
                Title = todoInsertDto.Title,
                DescriptionItem = todoInsertDto.DescriptionItem,
                CreatedDate = todoInsertDto.CreatedDate,
                EndedDate = todoInsertDto.EndedDate,
                isCompleted = todoInsertDto.isCompleted,
            };

            await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();

            var itemDto = new TodoDto
            {
                Id = item.Id,
                Title = item.Title,
                DescriptionItem = item.DescriptionItem,
                CreatedDate = item.CreatedDate,
                EndedDate = item.EndedDate,
                isCompleted = item.isCompleted
            };

            return itemDto;
        }

        public async Task<TodoDto> UpdateItem(int id, TodoUpdateDto todoUpdateDto)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                item.Id = todoUpdateDto.Id;
                item.Title = todoUpdateDto.Title;
                item.DescriptionItem = todoUpdateDto.DescriptionItem;
                item.CreatedDate = todoUpdateDto.CreatedDate;
                item.EndedDate = todoUpdateDto.EndedDate;
                item.isCompleted = todoUpdateDto.isCompleted;

                await _context.SaveChangesAsync();

                var itemDto = new TodoDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    DescriptionItem = item.DescriptionItem,
                    CreatedDate = item.CreatedDate,
                    EndedDate = item.EndedDate,
                    isCompleted = item.isCompleted
                };
                return itemDto;
            }
            return null;
        }
        public async Task<TodoDto> DeleteItem(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                var itemDto = new TodoDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    DescriptionItem = item.DescriptionItem,
                    CreatedDate = item.CreatedDate,
                    EndedDate = item.EndedDate,
                    isCompleted = item.isCompleted
                };
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return itemDto;
            }
            return null;
        }

       
    }
}
