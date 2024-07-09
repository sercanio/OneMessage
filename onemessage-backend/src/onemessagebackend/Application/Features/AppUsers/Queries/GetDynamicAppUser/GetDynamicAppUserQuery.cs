using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.AppUsers.Queries.GetDynamicAppUser
{
    public class GetDynamicAppUserQuery : IRequest<GetListResponse<GetDynamicAppUserListItemDto>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }
        public bool BypassCache { get; }

        public class GetDynamicAppUserQueryHandler : IRequestHandler<GetDynamicAppUserQuery, GetListResponse<GetDynamicAppUserListItemDto>>
        {
            private readonly IMapper _mapper;
            private readonly AppUserBusinessRules _appUserBusinessRules;
            private readonly IAppUserRepository _appUserRepository;

            public GetDynamicAppUserQueryHandler(IMapper mapper, AppUserBusinessRules appUserBusinessRules, IAppUserRepository appUserRepository)
            {
                _mapper = mapper;
                _appUserBusinessRules = appUserBusinessRules;
                _appUserRepository = appUserRepository;
            }

            public async Task<GetListResponse<GetDynamicAppUserListItemDto>> Handle(GetDynamicAppUserQuery request, CancellationToken cancellationToken)
            {
                var appUsers = await _appUserRepository.GetListByDynamicAsync(
                    request.DynamicQuery,
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetDynamicAppUserListItemDto> response = _mapper.Map<GetListResponse<GetDynamicAppUserListItemDto>>(appUsers);

                return response;
            }
        }
    }
}
