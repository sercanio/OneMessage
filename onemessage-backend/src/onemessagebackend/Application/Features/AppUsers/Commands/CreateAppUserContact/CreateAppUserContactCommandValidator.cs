using FluentValidation;

namespace Application.Features.AppUsers.Commands.CreateAppUserContact;

public class CreateAppUserContactCommandValidator : AbstractValidator<CreateAppUserContactCommand>
{
    public CreateAppUserContactCommandValidator() { }
}