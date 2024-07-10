namespace Application.Features.Messages.Queries.GetListByAppUserId;
public class MessageDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
}