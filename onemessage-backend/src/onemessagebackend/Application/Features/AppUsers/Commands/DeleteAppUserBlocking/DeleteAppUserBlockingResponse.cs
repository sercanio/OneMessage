using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Commands.DeleteAppUserBlocking;

public class DeleteAppUserBlockingResponse : IResponse
{
    public Guid BlockingUserId { get; set; }
}
