using Application.Features.AppUsers.Constants;
using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using System.Security.Claims;
using static Application.Features.AppUsers.Constants.AppUsersOperationClaims;

namespace Application.Features.AppUsers.Commands.CreateAppUserBlocking;

public class CreateAppUserBlockingCommand : IRequest<CreateAppUserBlockingResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid BlockUserId { get; set; }

    public string[] Roles => new[] { Admin, Write, AppUsersOperationClaims.CreateAppUserBlocking };

    public class CreateAppUserBlockingCommandHandler : IRequestHandler<CreateAppUserBlockingCommand, CreateAppUserBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAppUserBlockingCommandHandler(IMapper mapper, AppUserBusinessRules appUserBusinessRules, IAppUserRepository appUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserRepository = appUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateAppUserBlockingResponse> Handle(CreateAppUserBlockingCommand request, CancellationToken cancellationToken)
        {
            var authUserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid authUserIdParsed = Guid.Parse(authUserId!);

            AppUser? authAppUser = await _appUserRepository.GetAsync(predicate: au => au.UserId == authUserIdParsed);
            await _appUserBusinessRules.AppUserIdShouldExistWhenSelected(authAppUser!.Id, cancellationToken);

            AppUser? blockUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.BlockUserId);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(blockUser);

            // Initialize the Blockings collection if it's null
            authAppUser.Blockings ??= new List<AppUser>();

            // Add the block user to the authenticated user's blockings
            authAppUser.Blockings.Add(blockUser!);
            await _appUserRepository.UpdateAsync(authAppUser);

            CreateAppUserBlockingResponse response = _mapper.Map<CreateAppUserBlockingResponse>(authAppUser);
            return response;
        }
    }
}
