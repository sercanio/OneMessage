using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
    public bool Seen { get; set; }
    public AppUser Sender { get; set; }
    public AppUser Receiver { get; set; }
}