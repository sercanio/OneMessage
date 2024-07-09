using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AppUsers.Queries.GetList;

public class GetListAppUserQuery : IRequest<GetListResponse<GetListAppUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAppUserQueryHandler : IRequestHandler<GetListAppUserQuery, GetListResponse<GetListAppUserListItemDto>>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetListAppUserQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAppUserListItemDto>> Handle(GetListAppUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AppUser> appUsers = await _appUserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAppUserListItemDto> response = _mapper.Map<GetListResponse<GetListAppUserListItemDto>>(appUsers);
            return response;
        }
    }
}