using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Messages;

public interface IMessageService
{
    Task<Message?> GetAsync(
        Expression<Func<Message, bool>> predicate,
        Func<IQueryable<Message>, IIncludableQueryable<Message, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Message>?> GetListAsync(
        Expression<Func<Message, bool>>? predicate = null,
        Func<IQueryable<Message>, IOrderedQueryable<Message>>? orderBy = null,
        Func<IQueryable<Message>, IIncludableQueryable<Message, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Message> AddAsync(Message message);
    Task<Message> UpdateAsync(Message message);
    Task<Message> DeleteAsync(Message message, bool permanent = false);
}
