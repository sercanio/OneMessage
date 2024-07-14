using Application.Features.AppUsers.Commands.Create;
using Application.Features.AppUsers.Commands.CreateAppUserBlocking;
using Application.Features.AppUsers.Commands.CreateAppUserContact;
using Application.Features.AppUsers.Commands.Delete;
using Application.Features.AppUsers.Commands.DeleteAppUserBlocking;
using Application.Features.AppUsers.Commands.DeleteAppUserContact;
using Application.Features.AppUsers.Commands.Update;
using Application.Features.AppUsers.Queries.GetAppUserByUserId;
using Application.Features.AppUsers.Queries.GetById;
using Application.Features.AppUsers.Queries.GetDynamicAppUser;
using Application.Features.AppUsers.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AppUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateAppUserCommand, AppUser>();
            CreateMap<AppUser, CreatedAppUserResponse>();

            CreateMap<UpdateAppUserCommand, AppUser>();
            CreateMap<AppUser, UpdatedAppUserResponse>();

            CreateMap<DeleteAppUserCommand, AppUser>();
            CreateMap<AppUser, DeletedAppUserResponse>();

            CreateMap<AppUser, GetByIdAppUserResponse>();
            CreateMap<AppUser, ContactDto>();
            CreateMap<AppUser, BlockingDto>();

            CreateMap<AppUser, GetAppUserByUserIdResponse>();

            CreateMap<AppUser, CreateAppUserContactResponse>();
            CreateMap<CreateAppUserContactResponse, AppUser>();

            CreateMap<DeleteAppUserContactCommand, AppUser>();
            CreateMap<AppUser, DeleteAppUserContactResponse>();

            CreateMap<CreateAppUserBlockingCommand, AppUser>();
            CreateMap<AppUser, CreateAppUserBlockingResponse>();

            CreateMap<DeleteAppUserBlockingCommand, AppUser>();
            CreateMap<AppUser, DeleteAppUserBlockingResponse>();

            CreateMap<AppUser, GetListAppUserListItemDto>();
            CreateMap<IPaginate<AppUser>, GetListResponse<GetListAppUserListItemDto>>();

            CreateMap<AppUser, GetDynamicAppUserListItemDto>();
            CreateMap<IPaginate<AppUser>, GetListResponse<GetDynamicAppUserListItemDto>>();
        }
    }
}
