using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleJwt.Models;
using SimpleJwt.Services;

namespace SimpleJwt.Controllers;

[Route("api/auth")]
public class AuthController : BaseController
{

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterNewCustomer([FromBody] AuthRequest request)
    {
        var register = await _authService.Register(request);
        return Created("/api/auth/register", register);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] AuthRequest request)

    {
        var response = await _authService.Login(request);
        return Ok(response);
    }

}