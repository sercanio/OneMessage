using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Messages;

public class MessageManager : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly MessageBusinessRules _messageBusinessRules;

    public MessageManager(IMessageRepository messageRepository, MessageBusinessRules messageBusinessRules)
    {
        _messageRepository = messageRepository;
        _messageBusinessRules = messageBusinessRules;
    }

    public async Task<Message?> GetAsync(
        Expression<Func<Message, bool>> predicate,
        Func<IQueryable<Message>, IIncludableQueryable<Message, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Message? message = await _messageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return message;
    }

    public async Task<IPaginate<Message>?> GetListAsync(
        Expression<Func<Message, bool>>? predicate = null,
        Func<IQueryable<Message>, IOrderedQueryable<Message>>? orderBy = null,
        Func<IQueryable<Message>, IIncludableQueryable<Message, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Message> messageList = await _messageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return messageList;
    }

    public async Task<Message> AddAsync(Message message)
    {
        Message addedMessage = await _messageRepository.AddAsync(message);

        return addedMessage;
    }

    public async Task<Message> UpdateAsync(Message message)
    {
        Message updatedMessage = await _messageRepository.UpdateAsync(message);

        return updatedMessage;
    }

    public async Task<Message> DeleteAsync(Message message, bool permanent = false)
    {
        Message deletedMessage = await _messageRepository.DeleteAsync(message);

        return deletedMessage;
    }
}
