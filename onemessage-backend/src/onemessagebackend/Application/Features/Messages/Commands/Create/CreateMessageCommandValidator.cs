using FluentValidation;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(c => c.ReceiverId).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
    }
}