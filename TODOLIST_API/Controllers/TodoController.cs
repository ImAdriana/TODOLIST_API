using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TODOLIST_API.Context;
using TODOLIST_API.DTO;
using TODOLIST_API.Models;
using TODOLIST_API.Service;
using TODOLIST_API.Validator;


namespace TODOLIST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        AppDbContext _context;
        private IValidator<TodoInsertDto> _todoInsertValidator;
        private IValidator<TodoUpdateDto> _todoUpdateValidator;
        private ITodoService _todoService;
        public TodoController(AppDbContext db, IValidator<TodoInsertDto> todoInsertValidator, IValidator<TodoUpdateDto> todoUpdateValidator, ITodoService todoService)
        {
            _context = db;
            _todoInsertValidator = todoInsertValidator;
            _todoUpdateValidator = todoUpdateValidator;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoDto>> Get() =>
            await _todoService.Get();

        [HttpGet("task/{id}")]
        public async Task<ActionResult<TodoDto>> GetTask(int id)
        {
            var itemDto = await _todoService.GetById(id);
            return itemDto != null ? Ok(itemDto) : NotFound();

        }

        [HttpGet("task/status/{isCompleted}")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetItemIsCompleted(bool isCompleted)
        {
            var itemDto = await _todoService.GetItemIsCompleted(isCompleted);
            return itemDto !=null ? Ok(itemDto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> InsertItem(TodoInsertDto todoInsertDto)
        {
            var validationResult = await _todoInsertValidator.ValidateAsync(todoInsertDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            var itemDto = await _todoService.InsertItem(todoInsertDto);
            return CreatedAtAction(nameof(GetTask), new { id = itemDto.Id }, itemDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDto>> UpdateItem(int id, TodoUpdateDto todoUpdateDto)
        {
            var validationResult = await _todoUpdateValidator.ValidateAsync(todoUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var itemDto = await _todoService.UpdateItem(id, todoUpdateDto);
            return itemDto != null ? Ok(itemDto) : NotFound();



        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoDto>> DeleteItem(int id)
        {
            var itemDto = await _todoService.DeleteItem(id);
            return itemDto != null ? Ok(itemDto) : NotFound();
        }
    }
}
