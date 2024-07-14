using Application.Features.AppUsers.Queries.GetById;
using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppUsers.Queries.GetAppUserByUserId;

public class GetAppUserByUserIdQuery : IRequest<GetAppUserByUserIdResponse>
{
    public Guid UserId { get; set; }

    public class GetAppUserByUserIdQueryHandler : IRequestHandler<GetAppUserByUserIdQuery, GetAppUserByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public GetAppUserByUserIdQueryHandler(IMapper mapper, IAppUserRepository appUserRepository, AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<GetAppUserByUserIdResponse> Handle(GetAppUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(
                predicate: au => au.UserId == request.UserId,
                include: au => au
                    .Include(a => a.Contacts)
                    .Include(a => a.Blockings),
                cancellationToken: cancellationToken);

            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);

            GetAppUserByUserIdResponse response = _mapper.Map<GetAppUserByUserIdResponse>(appUser);

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
