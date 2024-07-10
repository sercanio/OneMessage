using FluentValidation;

namespace Application.Features.AppUsers.Commands.DeleteAppUserContact;

public class DeleteAppUserContactCommandValidator : AbstractValidator<DeleteAppUserContactCommand>
{
    public DeleteAppUserContactCommandValidator() { }
}