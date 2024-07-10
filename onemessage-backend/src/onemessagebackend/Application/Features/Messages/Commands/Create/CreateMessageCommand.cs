using Application.Features.AppUsers.Rules;
using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Services.AppUsers;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using System.Security.Claims;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommand : IRequest<CreatedMessageResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid ReceiverId { get; set; }
    public required string Content { get; set; }

    public string[] Roles => [Admin, Write, MessagesOperationClaims.Create];

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppUserService _appUserService;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules, IHttpContextAccessor httpContextAccessor, IAppUserService appUserService, AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
            _httpContextAccessor = httpContextAccessor;
            _appUserService = appUserService;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var authUserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid authUserIdParsed = Guid.Parse(authUserId!);

            AppUser? authAppUser = await _appUserService.GetAsync(predicate: au => au.UserId == authUserIdParsed);
            await _appUserBusinessRules.AppUserIdShouldExistWhenSelected(authAppUser!.Id, cancellationToken);

            Message message = _mapper.Map<Message>(request);
            message.Sender = authAppUser;

            await _messageRepository.AddAsync(message, cancellationToken);

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(message);
            return response;
        }

    }
}