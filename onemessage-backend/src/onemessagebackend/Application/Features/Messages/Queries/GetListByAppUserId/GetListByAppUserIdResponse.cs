using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Queries.GetListByAppUserId;

public class GetListByAppUserIdResponse : IResponse
{
    public List<MessageDto> SentMessages { get; set; }
    public List<MessageDto> ReceivedMessages { get; set; }
}