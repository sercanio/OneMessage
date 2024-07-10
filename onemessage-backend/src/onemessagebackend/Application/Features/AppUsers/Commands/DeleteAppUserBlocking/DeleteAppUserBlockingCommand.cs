using Application.Features.AppUsers.Constants;
using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using System.Security.Claims;
using static Application.Features.AppUsers.Constants.AppUsersOperationClaims;

namespace Application.Features.AppUsers.Commands.DeleteAppUserBlocking
{
    public class DeleteAppUserBlockingCommand : IRequest<DeleteAppUserBlockingResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
    {
        public Guid BlockingId { get; set; }

        public string[] Roles => new[] { Admin, Write, AppUsersOperationClaims.DeleteAppUserBlocking };
    }

    public class DeleteAppUserBlockingCommandHandler : IRequestHandler<DeleteAppUserBlockingCommand, DeleteAppUserBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteAppUserBlockingCommandHandler(IMapper mapper, AppUserBusinessRules appUserBusinessRules, IAppUserRepository appUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserRepository = appUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DeleteAppUserBlockingResponse> Handle(DeleteAppUserBlockingCommand request, CancellationToken cancellationToken)
        {
            var authUserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (authUserId == null)
            {
                throw new ApplicationException("User not authenticated.");
            }

            Guid authUserIdparsed = Guid.Parse(authUserId);

            // Fetch the authenticated user with blockings loaded
            AppUser? authAppUser = await _appUserRepository.GetAsync(
                predicate: au => au.UserId == authUserIdparsed,
                include: au => au.Include(a => a.Blockings),
                cancellationToken: cancellationToken);

            await _appUserBusinessRules.AppUserIdShouldExistWhenSelected(authAppUser.Id, cancellationToken);

            // Ensure blockings list is initialized
            authAppUser.Blockings ??= new List<AppUser>();

            // Find the blocking to delete
            AppUser blockingUser = authAppUser.Blockings.FirstOrDefault(blocking => blocking.Id == request.BlockingId);
            if (blockingUser == null)
            {
                throw new ApplicationException($"Blocking with ID {request.BlockingId} not found for user {authAppUser.Id}.");
            }

            // Remove the blocking from the list
            authAppUser.Blockings.Remove(blockingUser);

            // Update the user in the repository
            await _appUserRepository.UpdateAsync(authAppUser);

            // Prepare response
            DeleteAppUserBlockingResponse response = _mapper.Map<DeleteAppUserBlockingResponse>(authAppUser);
            response.BlockingUserId = request.BlockingId;

            return response;
        }
    }
}
