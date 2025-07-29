using Microsoft.AspNetCore.Mvc;
using TODOLIST_API.DTO;

namespace TODOLIST_API.Service
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDto>> Get();
        Task <TodoDto> GetById(int id);
        Task<IEnumerable<TodoDto>> GetItemIsCompleted(bool isCompleted);
        Task<TodoDto> InsertItem(TodoInsertDto todoInsertDto);
        Task<TodoDto> UpdateItem(int id, TodoUpdateDto todoUpdateDto);

        Task<TodoDto> DeleteItem(int id);

    }
}
