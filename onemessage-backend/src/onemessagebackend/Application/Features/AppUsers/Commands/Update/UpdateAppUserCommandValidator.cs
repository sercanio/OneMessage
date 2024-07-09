using FluentValidation;

namespace Application.Features.AppUsers.Commands.Update;

public class UpdateAppUserCommandValidator : AbstractValidator<UpdateAppUserCommand>
{
    public UpdateAppUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.LastSeen).NotEmpty();
    }
}