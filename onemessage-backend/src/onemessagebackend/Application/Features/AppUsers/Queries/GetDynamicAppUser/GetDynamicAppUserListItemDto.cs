using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Queries.GetDynamicAppUser;

public class GetDynamicAppUserListItemDto : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}
