using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AppUsers.Queries.GetList;

public class GetListAppUserListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? AvatarURL { get; set; }
    public string UserName { get; set; }
    public string Status { get; set; }
    public DateTime LastSeen { get; set; }
}