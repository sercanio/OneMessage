namespace Application.Features.AppUsers.Queries.GetById;
public class BlockingDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Status { get; set; }
    public string? AvatarURL { get; set; }
}
