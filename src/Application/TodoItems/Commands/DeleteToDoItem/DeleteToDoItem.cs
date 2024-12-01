using ToDoApp.Application.Common.Interfaces;

namespace ToDoApp.Application.TodoItems.Commands.DeleteToDoItem;

public record class DeleteToDoItemCommand : IRequest<int>
{
    public required List<int> Id { get; set; }
}

public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteToDoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        foreach(var itemId in request.Id)
        {
            var toDoItem = await _context.TodoItems.Where(x => x.Id == itemId).SingleAsync(cancellationToken);

            if (toDoItem != null)
            {
                _context.TodoItems.Remove(toDoItem);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return 1;
    }
}
