using Application.Features.Messages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Messages.Rules;

public class MessageBusinessRules : BaseBusinessRules
{
    private readonly IMessageRepository _messageRepository;
    private readonly ILocalizationService _localizationService;

    public MessageBusinessRules(IMessageRepository messageRepository, ILocalizationService localizationService)
    {
        _messageRepository = messageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MessagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MessageShouldExistWhenSelected(Message? message)
    {
        if (message == null)
            await throwBusinessException(MessagesBusinessMessages.MessageNotExists);
    }

    public async Task MessageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Message? message = await _messageRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MessageShouldExistWhenSelected(message);
    }
}