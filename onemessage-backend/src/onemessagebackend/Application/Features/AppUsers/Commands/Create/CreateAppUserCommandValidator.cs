using FluentValidation;

namespace Application.Features.AppUsers.Commands.Create;

public class CreateAppUserCommandValidator : AbstractValidator<CreateAppUserCommand>
{
    public CreateAppUserCommandValidator()
    {
        RuleFor(c => c.UserName).NotEmpty();
    }
}