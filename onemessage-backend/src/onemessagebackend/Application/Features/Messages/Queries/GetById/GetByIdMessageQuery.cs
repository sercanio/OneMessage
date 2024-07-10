using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageQuery : IRequest<GetByIdMessageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMessageQueryHandler : IRequestHandler<GetByIdMessageQuery, GetByIdMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public GetByIdMessageQueryHandler(IMapper mapper, IMessageRepository messageRepository, MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<GetByIdMessageResponse> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
        {
            Message? message = await _messageRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);

            GetByIdMessageResponse response = _mapper.Map<GetByIdMessageResponse>(message);
            return response;
        }
    }
}