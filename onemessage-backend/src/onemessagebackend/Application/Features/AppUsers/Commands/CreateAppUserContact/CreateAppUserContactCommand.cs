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

namespace Application.Features.AppUsers.Commands.CreateAppUserContact;

public class CreateAppUserContactCommand : IRequest<CreateAppUserContactResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid AppUserID { get; set; }

    public string[] Roles => [Admin, Write, AppUsersOperationClaims.CreateAppUserContact];

    public class CreateAppUserContactCommandHandler : IRequestHandler<CreateAppUserContactCommand, CreateAppUserContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAppUserContactCommandHandler(IMapper mapper, AppUserBusinessRules appUserBusinessRules, IAppUserRepository appUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserRepository = appUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateAppUserContactResponse> Handle(CreateAppUserContactCommand request, CancellationToken cancellationToken)
        {
            var authUserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid authUserIdparsed = Guid.Parse(authUserId!);

            AppUser? authAppUser = await _appUserRepository.GetAsync(predicate: au => au.UserId == authUserIdparsed);
            await _appUserBusinessRules.AppUserIdShouldExistWhenSelected(authAppUser.Id, cancellationToken);

            AppUser? appUser = await _appUserRepository.GetAsync(predicate: au => au.Id == authAppUser.Id);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);


            AppUser? contactUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.AppUserID);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(contactUser);
            if (authAppUser.Contacts == null)
            {
                authAppUser.Contacts = new List<AppUser>();
            }

            appUser.Contacts.Add(contactUser);
            await _appUserRepository.UpdateAsync(appUser);

            CreateAppUserContactResponse response = _mapper.Map<CreateAppUserContactResponse>(appUser);
            response.Id = request.AppUserID;

            return response;
        }
    }
}
