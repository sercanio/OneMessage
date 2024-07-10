﻿using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AppUser : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string? AvatarURL { get; set; }
    public string UserName { get; set; }
    public string? Status { get; set; }
    public DateTime? LastSeen { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<AppUser> Contacts { get; set; }
    public virtual ICollection<AppUser> Blockings { get; set; }
    public virtual ICollection<Message> MessagesSent { get; set; }
    public virtual ICollection<Message> MessagesReceived { get; set; }

}
