using FluentValidation;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SenderId).NotEmpty();
        RuleFor(c => c.ReceiverId).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.Seen).NotEmpty();
    }
}