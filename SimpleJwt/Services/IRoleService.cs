using SimpleJwt.Entities;

namespace SimpleJwt.Services;

public interface IRoleService
{
    Task<Role> SaveOrGet(string role);
}