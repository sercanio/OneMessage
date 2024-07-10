using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Message : Entity<Guid>
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
    public bool Seen { get; set; }

    public virtual AppUser Sender { get; set; }
    public virtual AppUser Receiver { get; set; }
}
