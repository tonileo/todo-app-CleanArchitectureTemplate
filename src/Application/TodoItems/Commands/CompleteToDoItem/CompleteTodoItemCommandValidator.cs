using System;

namespace ToDoApp.Application.TodoItems.Commands.CompleteToDoItem;

public class CompleteTodoItemCommandValidator : AbstractValidator<CompleteToDoItemCommand>
{
    public CompleteTodoItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("No items where selected for completion!");
    }
}
