using FluentValidation;
using TODOLIST_API.DTO;

namespace TODOLIST_API.Validator
{
    public class TodoUpdateValidator: AbstractValidator<TodoUpdateDto>
    {
        public TodoUpdateValidator() {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is obligatory");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is obligatory");
            RuleFor(x => x.DescriptionItem).NotEmpty().WithMessage(x => "Description is obligatory");
            RuleFor(x => x.CreatedDate).NotNull().WithMessage(x => "Created date is obligatory");
            RuleFor(x => x.EndedDate).GreaterThan(x => x.CreatedDate).WithMessage(x => "{PropertyName} must be greater than created date");
            RuleFor(x => x.isCompleted).NotNull().WithMessage(x => "Is important a status");

        }
    }
}
