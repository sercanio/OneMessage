using Application.Features.AppUsers.Queries.GetById;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Queries.GetAppUserByUserId;

public class GetAppUserByUserIdResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? AvatarURL { get; set; }
    public string UserName { get; set; }
    public string Status { get; set; }
    public DateTime LastSeen { get; set; }
    public List<ContactDto> Contacts { get; set; } = new();
    public List<BlockingDto> Blockings { get; set; } = new();
}