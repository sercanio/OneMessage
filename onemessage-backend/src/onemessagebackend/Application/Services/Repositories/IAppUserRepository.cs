using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAppUserRepository : IAsyncRepository<AppUser, Guid>, IRepository<AppUser, Guid>
{
}