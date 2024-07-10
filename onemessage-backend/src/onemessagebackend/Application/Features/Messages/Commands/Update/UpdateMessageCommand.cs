using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommand : IRequest<UpdatedMessageResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid SenderId { get; set; }
    public required Guid ReceiverId { get; set; }
    public required string Content { get; set; }
    public required bool Seen { get; set; }

    public string[] Roles => [Admin, Write, MessagesOperationClaims.Update];

    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, UpdatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public UpdateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<UpdatedMessageResponse> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            Message? message = await _messageRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);
            message = _mapper.Map(request, message);

            await _messageRepository.UpdateAsync(message!);

            UpdatedMessageResponse response = _mapper.Map<UpdatedMessageResponse>(message);
            return response;
        }
    }
}