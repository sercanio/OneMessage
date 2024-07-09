using Application.Features.AppUsers.Commands.Create;
using Application.Features.AppUsers.Commands.Delete;
using Application.Features.AppUsers.Commands.Update;
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

            CreateMap<AppUser, GetListAppUserListItemDto>();
            CreateMap<IPaginate<AppUser>, GetListResponse<GetListAppUserListItemDto>>();

            CreateMap<AppUser, GetDynamicAppUserListItemDto>();
            CreateMap<IPaginate<AppUser>, GetListResponse<GetDynamicAppUserListItemDto>>();
        }
    }
}
