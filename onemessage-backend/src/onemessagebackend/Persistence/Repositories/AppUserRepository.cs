using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AppUserRepository : EfRepositoryBase<AppUser, Guid, BaseDbContext>, IAppUserRepository
{
    public AppUserRepository(BaseDbContext context) : base(context)
    {
    }
}