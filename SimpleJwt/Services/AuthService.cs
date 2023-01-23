using Microsoft.AspNetCore.Mvc;
using SimpleJwt.Entities;
using SimpleJwt.Exceptions;
using SimpleJwt.Models;
using SimpleJwt.Repositories;
using SimpleJwt.Security;

namespace SimpleJwt.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<UserCredential> _repository;
    private readonly IRoleService _roleService;
    private readonly ICustomerService _customerService;
    private readonly IPersistence _persistence;
    private readonly IJwtUtils _jwtUtils;

    private readonly SecurityUtils _securityUtils;

    public AuthService(IRepository<UserCredential> repository, SecurityUtils securityUtils, IRoleService roleService,
        IPersistence persistence, ICustomerService customerService, IJwtUtils jwtUtils)
    {
        _repository = repository;
        _securityUtils = securityUtils;
        _roleService = roleService;
        _persistence = persistence;
        _customerService = customerService;
        _jwtUtils = jwtUtils;
    }

    public async Task<LoginResponse> LoadByEmail(string email)
    {
        var user = await _repository.FindAsync(credential => credential.Email.Equals(email), new[] { "Role" });
        if (user is null) throw new UnauthorizedException("invalid credential");
        return new LoginResponse
        {
            Email = user.Email,
            Role = user.Role.ERole.ToString()
        };
    }

    public async Task<RegisterResponse> Register(AuthRequest request)
    {
        var hashPassword = _securityUtils.HashPassword(request.Password);
        request.Password = hashPassword;

        return await _persistence.ExecuteTransactionAsync(async () =>
        {
            var role = await _roleService.SaveOrGet("Customer");

            var userCredential = new UserCredential
            {
                Email = request.Email,
                Password = hashPassword,
                Role = role
            };

            var user = await _repository.SaveAsync(userCredential);
            await _persistence.SaveChangesAsync();

            await _customerService.Create(new Customer { UserCredential = user });

            return new RegisterResponse
            {
                Email = user.Email,
                Role = user.Role.ERole.ToString()
            };
        });
    }

    public async Task<LoginResponse> Login(AuthRequest request)
    {
        var user = await _repository.FindAsync(credential => credential.Email.Equals(request.Email), new[] { "Role" });
        if (user is null) throw new UnauthorizedException("invalid credential");
        var validate = _securityUtils.Validate(request.Password, user.Password);
        if (!validate) throw new UnauthorizedException("invalid credential");

        var token = _jwtUtils.GenerateToken(user);

        return new LoginResponse
        {
            Email = user.Email,
            AccessToken = token,
            Role = user.Role.ERole.ToString()
        };
    }
}