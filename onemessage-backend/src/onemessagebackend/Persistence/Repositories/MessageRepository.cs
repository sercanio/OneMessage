using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MessageRepository : EfRepositoryBase<Message, Guid, BaseDbContext>, IMessageRepository
{
    public MessageRepository(BaseDbContext context) : base(context)
    {
    }
}