using ToDoApp.Application.Common.Interfaces;

namespace ToDoApp.Application.TodoItems.Commands.CompleteToDoItem;

public record class CompleteToDoItemCommand : IRequest<int>
{
    public required List<int> Id { get; init; }
}

public class CompleteToDoItemCommandHandler : IRequestHandler<CompleteToDoItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CompleteToDoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
    {
         foreach(var toDoItemId in request.Id)
        {
            var toDoItem = await _context.TodoItems.Where(x => x.Id == toDoItemId).SingleAsync(cancellationToken);

            if (toDoItem != null)
            {
                toDoItem.Done = true;
            }
        }
        
        await _context.SaveChangesAsync(cancellationToken);

        return 1;
    }
}