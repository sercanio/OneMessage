using FluentValidation;

namespace Application.Features.AppUsers.Commands.DeleteAppUserBlocking;

public class DeleteAppUserBlockingCommandValidator : AbstractValidator<DeleteAppUserBlockingCommand>
{
    public DeleteAppUserBlockingCommandValidator() { }
}