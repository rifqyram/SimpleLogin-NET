using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleJwt.Controllers;

[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
}