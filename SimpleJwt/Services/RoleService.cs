using SimpleJwt.Entities;
using SimpleJwt.Exceptions;
using SimpleJwt.Repositories;

namespace SimpleJwt.Services;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> _repository;
    private readonly IPersistence _persistence;

    public RoleService(IRepository<Role> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public async Task<Role> SaveOrGet(string role)
    {
        try
        {
            var eRole = Enum.Parse<ERole>(role, true);
            var saveRole = await _repository.FindAsyncOrElse(
                r => r.ERole.Equals(eRole), async () => await _repository.SaveAsync(new Role
                {
                    Id = default,
                    ERole = eRole
                })
            );
            await _persistence.SaveChangesAsync();
            return saveRole;
        }
        catch (ArgumentNullException e)
        {
            throw new NotFoundException("role not found");
        }
    }
}