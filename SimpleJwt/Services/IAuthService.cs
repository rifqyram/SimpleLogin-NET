using SimpleJwt.Entities;
using SimpleJwt.Models;

namespace SimpleJwt.Services;

public interface IAuthService
{
    Task<LoginResponse> LoadByEmail(string email);
    Task<RegisterResponse> Register(AuthRequest request);
    Task<LoginResponse> Login(AuthRequest request);
}