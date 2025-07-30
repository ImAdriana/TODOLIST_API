using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOLIST_API.Context;
using TODOLIST_API.DTO;
using TODOLIST_API.Mapping;
using TODOLIST_API.Models;
using TODOLIST_API.Repository;

namespace TODOLIST_API.Service
{
    public class TodoService : ITodoService
    {
        private ITodoRepository<TodoItem> _todoRepository;
        private IMapper _mapper;
        public TodoService( ITodoRepository<TodoItem> todoRepository,
            IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TodoDto>> Get() {
            var item = await _todoRepository.GetAll();
            return item.Select(m => _mapper.Map<TodoDto>(m));

        }
        
        public async Task<TodoDto> GetById(int id)
        {
            var item = await _todoRepository.GetById(id);
            if (item != null)
            {
                var todoDto = _mapper.Map<TodoDto>(item);
                return todoDto;
            }
            return null;
        }
        public async Task<IEnumerable<TodoDto>> GetItemIsCompleted(bool isCompleted)
        {
            var items = await _todoRepository.IsTaskCompleted(isCompleted);
            if (items != null)
            {
                return items.Select(m => _mapper.Map<TodoDto>(m)); 
            }
            return null;
        }

        public async Task<TodoDto> InsertItem(TodoInsertDto todoInsertDto)
        {
            var item = _mapper.Map<TodoItem>(todoInsertDto);

            await _todoRepository.Add(item);
            await _todoRepository.Save();

            var itemDto = _mapper.Map<TodoDto>(item);

            return itemDto;
        }

        public async Task<TodoDto> UpdateItem(int id, TodoUpdateDto todoUpdateDto)
        {
            var item = await _todoRepository.GetById(id);
            if (item != null)
            {
                item = _mapper.Map<TodoUpdateDto, TodoItem>(todoUpdateDto, item);

                await _todoRepository.Save();

                var itemDto = _mapper.Map<TodoDto>(item);
                return itemDto;
            }
            return null;
        }
        public async Task<TodoDto> DeleteItem(int id)
        {
            var item = await _todoRepository.GetById(id);
            if (item != null)
            {
                var itemDto = _mapper.Map<TodoDto>(item);

                _todoRepository.Delete(item);
                await _todoRepository.Save();
                return itemDto;
            }
            return null;
        }

       
    }
}
