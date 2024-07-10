using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Commands.Delete;

public class DeletedMessageResponse : IResponse
{
    public Guid Id { get; set; }
}