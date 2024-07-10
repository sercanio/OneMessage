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

namespace Application.Features.AppUsers.Commands.DeleteAppUserContact;

public class DeleteAppUserContactCommand : IRequest<DeleteAppUserContactResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid ContactId { get; set; }

    public string[] Roles => new[] { Admin, Write, AppUsersOperationClaims.DeleteAppUserContact };

    public class DeleteAppUserContactCommandHandler : IRequestHandler<DeleteAppUserContactCommand, DeleteAppUserContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteAppUserContactCommandHandler(IMapper mapper, AppUserBusinessRules appUserBusinessRules, IAppUserRepository appUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserRepository = appUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DeleteAppUserContactResponse> Handle(DeleteAppUserContactCommand request, CancellationToken cancellationToken)
        {
            var authUserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid authUserIdParsed = Guid.Parse(authUserId!);

            AppUser? authAppUser = await _appUserRepository.GetAsync(
                predicate: au => au.UserId == authUserIdParsed,
                include: au => au.Include(a => a.Contacts));

            await _appUserBusinessRules.AppUserIdShouldExistWhenSelected(authAppUser.Id, cancellationToken);

            authAppUser!.Contacts ??= new List<AppUser>();

            AppUser? contactUser = authAppUser.Contacts.FirstOrDefault(contact => contact.Id == request.ContactId);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(contactUser);

            authAppUser.Contacts.Remove(contactUser!);
            await _appUserRepository.UpdateAsync(authAppUser);

            DeleteAppUserContactResponse response = _mapper.Map<DeleteAppUserContactResponse>(authAppUser);
            response.Id = request.ContactId;

            return response;
        }
    }
}
