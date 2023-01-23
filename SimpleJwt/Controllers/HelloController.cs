using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleJwt.Controllers;

[Route("api/hello")]
public class HelloController : BaseController
{
    [HttpGet, Authorize(Roles = "Customer")]
    public string getHello()
    {
        var me = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Email));
        return $"Hello with me {me.Value}";
    }
}