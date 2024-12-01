﻿using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.TodoItems.Commands.CreateTodoItem;
using ToDoApp.Application.Common.Exceptions;

namespace ToDoApp.Web.Controllers;

public class ToDoItemController : Controller
{
    private readonly ISender _sender;

    public ToDoItemController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            // Set all error messages as single string to TempData["Errors"] variable
            foreach (var error in ex.Errors)
            {
                TempData["Errors"] = string.Join(", ", error.Value);
            }
        }

        return Redirect("/");
    }
}
