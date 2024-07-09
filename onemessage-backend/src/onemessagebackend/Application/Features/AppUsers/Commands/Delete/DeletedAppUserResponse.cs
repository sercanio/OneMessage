using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppUsers.Commands.Delete;

public class DeletedAppUserResponse : IResponse
{
    public Guid Id { get; set; }
}