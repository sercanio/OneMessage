using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppUsers.Queries.GetById;

public class GetByIdAppUserQuery : IRequest<GetByIdAppUserResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQuery, GetByIdAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public GetByIdAppUserQueryHandler(IMapper mapper, IAppUserRepository appUserRepository, AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<GetByIdAppUserResponse> Handle(GetByIdAppUserQuery request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(
                predicate: au => au.Id == request.Id,
                include: au => au
                    .Include(a => a.Contacts)
                    .Include(a => a.Blockings),
                cancellationToken: cancellationToken);

            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);

            GetByIdAppUserResponse response = _mapper.Map<GetByIdAppUserResponse>(appUser);

            // Manually map the contacts
            response.Contacts = appUser.Contacts.Select(contact => new ContactDto
            {
                Id = contact.Id,
                UserName = contact.UserName,
                Status = contact.Status,
                AvatarURL = contact.AvatarURL
            }).ToList();

            // Manually map the blockings
            response.Blockings = appUser.Blockings.Select(blocking => new BlockingDto
            {
                Id = blocking.Id,
                UserName = blocking.UserName,
                Status = blocking.Status,
                AvatarURL = blocking.AvatarURL
            }).ToList();

            return response;
        }
    }
}
