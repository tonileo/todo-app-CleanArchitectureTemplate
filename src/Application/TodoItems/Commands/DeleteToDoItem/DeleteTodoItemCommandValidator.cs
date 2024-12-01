using System;

namespace ToDoApp.Application.TodoItems.Commands.DeleteToDoItem;

public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteToDoItemCommand>
{
    public DeleteTodoItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("No items where selected for deletion!");
    }
}
