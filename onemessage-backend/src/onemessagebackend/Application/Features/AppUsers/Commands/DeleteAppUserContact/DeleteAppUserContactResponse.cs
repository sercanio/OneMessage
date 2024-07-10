using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Commands.DeleteAppUserContact;

public class DeleteAppUserContactResponse : IResponse
{
    public Guid Id { get; set; }
}
