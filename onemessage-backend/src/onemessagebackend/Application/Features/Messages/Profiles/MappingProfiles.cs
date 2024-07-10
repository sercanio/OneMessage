using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.Update;
using Application.Features.Messages.Queries.GetById;
using Application.Features.Messages.Queries.GetList;
using Application.Features.Messages.Queries.GetListByAppUserId;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Messages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMessageCommand, Message>();
        CreateMap<Message, CreatedMessageResponse>();

        CreateMap<UpdateMessageCommand, Message>();
        CreateMap<Message, UpdatedMessageResponse>();

        CreateMap<DeleteMessageCommand, Message>();
        CreateMap<Message, DeletedMessageResponse>();

        CreateMap<Message, GetByIdMessageResponse>();
        CreateMap<Message, MessageDto>();

        CreateMap<Message, GetListMessageListItemDto>();
        CreateMap<IPaginate<Message>, GetListResponse<GetListMessageListItemDto>>();

        CreateMap<Message, GetListByAppUserIdResponse>();
        CreateMap<IPaginate<Message>, GetListResponse<GetListByAppUserIdResponse>>();
    }
}