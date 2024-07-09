using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.AppUsers.Commands.Update;

public class UpdateAppUserCommand : IRequest<UpdatedAppUserResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public string? AvatarURL { get; set; }
    public required string UserName { get; set; }
    public required string Status { get; set; }
    public required DateTime LastSeen { get; set; }

    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, UpdatedAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public UpdateAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository,
                                         AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<UpdatedAppUserResponse> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.Id, cancellationToken: cancellationToken);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);
            appUser = _mapper.Map(request, appUser);

            await _appUserRepository.UpdateAsync(appUser!);

            UpdatedAppUserResponse response = _mapper.Map<UpdatedAppUserResponse>(appUser);
            return response;
        }
    }
}