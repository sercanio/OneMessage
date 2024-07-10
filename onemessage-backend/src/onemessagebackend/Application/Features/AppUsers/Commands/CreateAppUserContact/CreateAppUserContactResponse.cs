using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Commands.CreateAppUserContact;

public class CreateAppUserContactResponse : IResponse
{
    public Guid Id { get; set; }
}
