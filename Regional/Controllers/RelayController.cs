using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regional.DTO;

namespace Regional.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RelayController {
    [HttpPost("")]
    public async Task<IActionResult> RelayMessage(RelayDto dto) {
        throw new NotImplementedException();
    }
}