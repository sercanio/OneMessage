using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;

namespace Application.Features.AppUsers.Commands.Delete;

public class DeleteAppUserCommand : IRequest<DeletedAppUserResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, DeletedAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public DeleteAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository,
                                         AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<DeletedAppUserResponse> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.Id, cancellationToken: cancellationToken);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);

            await _appUserRepository.DeleteAsync(appUser!);

            DeletedAppUserResponse response = _mapper.Map<DeletedAppUserResponse>(appUser);
            return response;
        }
    }
}