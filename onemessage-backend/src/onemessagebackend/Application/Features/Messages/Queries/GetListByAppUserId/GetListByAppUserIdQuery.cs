using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Messages.Queries.GetListByAppUserId
{
    public class GetListByAppUserIdQuery : IRequest<GetListByAppUserIdResponse>
    {
        public Guid AppUserId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListByAppUserIdQueryHandler : IRequestHandler<GetListByAppUserIdQuery, GetListByAppUserIdResponse>
        {
            private readonly IMessageRepository _messageRepository;
            private readonly IMapper _mapper;

            public GetListByAppUserIdQueryHandler(IMessageRepository messageRepository, IMapper mapper)
            {
                _messageRepository = messageRepository;
                _mapper = mapper;
            }

            public async Task<GetListByAppUserIdResponse> Handle(GetListByAppUserIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Message> paginatedMessages = await _messageRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                // Convert IPaginate<Message> to List<Message> or IEnumerable<Message>
                List<Message> messages = paginatedMessages.Items.ToList();

                // Filter and map messages
                var sentMessages = messages.Where(m => m.SenderId == request.AppUserId);
                var receivedMessages = messages.Where(m => m.ReceiverId == request.AppUserId);

                var response = new GetListByAppUserIdResponse
                {
                    SentMessages = _mapper.Map<List<MessageDto>>(sentMessages),
                    ReceivedMessages = _mapper.Map<List<MessageDto>>(receivedMessages)
                };

                return response;
            }
        }
    }
}