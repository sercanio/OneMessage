using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMessageRepository : IAsyncRepository<Message, Guid>, IRepository<Message, Guid>
{
}