using FluentValidation;

namespace Application.Features.Messages.Commands.Delete;

public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
{
    public DeleteMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}