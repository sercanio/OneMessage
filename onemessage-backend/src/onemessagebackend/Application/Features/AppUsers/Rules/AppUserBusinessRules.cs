using Application.Features.AppUsers.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.AppUsers.Rules;

public class AppUserBusinessRules : BaseBusinessRules
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ILocalizationService _localizationService;

    public AppUserBusinessRules(IAppUserRepository appUserRepository, ILocalizationService localizationService)
    {
        _appUserRepository = appUserRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AppUsersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AppUserShouldExistWhenSelected(AppUser? appUser)
    {
        if (appUser == null)
            await throwBusinessException(AppUsersBusinessMessages.AppUserNotExists);
    }

    public async Task AppUserIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _appUserRepository.GetAsync(
            predicate: au => au.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AppUserShouldExistWhenSelected(appUser);
    }
}