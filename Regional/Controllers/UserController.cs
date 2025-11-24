using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regional.DTO;

namespace Regional.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    [HttpPost("/local-register")]
    public async Task<IActionResult> RegisterUser(NewUserDto dto) {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost("timeout/vote")]
    public async Task<IActionResult> VoteTimeoutUser(VoteTimeoutUserDto dto) {
        throw new NotImplementedException();
    }
}