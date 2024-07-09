using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Queries.GetById;

public class GetByIdAppUserResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? AvatarURL { get; set; }
    public string UserName { get; set; }
    public string Status { get; set; }
    public DateTime LastSeen { get; set; }
}