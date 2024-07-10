using FluentValidation;

namespace Application.Features.AppUsers.Commands.CreateAppUserBlocking;

public class CreateAppUserBlockingCommandValidator : AbstractValidator<CreateAppUserBlockingCommand>
{
    public CreateAppUserBlockingCommandValidator() { }
}