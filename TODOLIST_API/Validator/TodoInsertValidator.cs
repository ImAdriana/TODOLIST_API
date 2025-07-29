using FluentValidation;
using TODOLIST_API.DTO;

namespace TODOLIST_API.Validator
{
    public class TodoInsertValidator: AbstractValidator<TodoInsertDto>
    {
        public TodoInsertValidator() {
            RuleFor(x=> x.Title).NotEmpty().WithMessage("Title is important");
            RuleFor(x => x.EndedDate).GreaterThan(x => x.CreatedDate).WithMessage("EndedDate must be greater than CreatedDate"); ;
        }
    }
}
