using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;

namespace Application.Features.AppUsers.Commands.Create;

public class CreateAppUserCommand : IRequest<CreatedAppUserResponse>, ILoggableRequest, ITransactionalRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? AvatarURL { get; set; }
    public required string UserName { get; set; }

    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreatedAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public CreateAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository,
                                         AppUserBusinessRules appUserBusinessRules, IUserService userService, IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<CreatedAppUserResponse> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = _mapper.Map<AppUser>(request);
            User user = await _userService.Register(new UserForRegisterDto() { Email = request.Email, Password = request.Password });

            await AddOperationClaimsToUser(user);

            appUser.UserId = user.Id;
            appUser.AvatarURL = request.AvatarURL;
            appUser.UserName = request.UserName;


            await _appUserRepository.AddAsync(appUser);

            CreatedAppUserResponse response = _mapper.Map<CreatedAppUserResponse>(appUser);
            return response;
        }

        private async Task AddOperationClaimsToUser(User user)
        {
            List<int> operationClaimIds = new List<int>
            {
                5,
                19,
                31,
                32,
                33,
                34,
                35
            };

            foreach (var claimId in operationClaimIds)
            {
                UserOperationClaim userOperationClaim = new UserOperationClaim() { UserId = user.Id, OperationClaimId = claimId };
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(new UserOperationClaim() { UserId = user.Id, OperationClaimId = claimId });

                await _userOperationClaimService.AddAsync(mappedUserOperationClaim);
            }
        }
    }
}