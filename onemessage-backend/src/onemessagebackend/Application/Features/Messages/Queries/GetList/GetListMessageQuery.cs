using Application.Features.Messages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageQuery : IRequest<GetListResponse<GetListMessageListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, GetListResponse<GetListMessageListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMessageListItemDto>> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Message> messages = await _messageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMessageListItemDto> response = _mapper.Map<GetListResponse<GetListMessageListItemDto>>(messages);
            return response;
        }
    }
}