using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regional.Database.Models;
using Regional.DTO;

namespace Regional.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessageController {
    [HttpPost("")]
    public async Task<IActionResult> SendMessage(NewMessageDto message) {
        throw new NotImplementedException();
    }

    [HttpPost("since/{date:datetime}")]
    public async Task<IActionResult> GetPublicMessageSince(DateTime since) {
        throw new NotImplementedException();
    }

    [HttpPost("since/{date:datetime}/{inboxId:guid}")]
    public async Task<IActionResult> GetPrivateMessageSince(string inboxId) {
        throw new NotImplementedException();
    }

    [HttpDelete("retract/{id:guid}")]
    public async Task<IActionResult> RetractMessage(string id) {
        throw new NotImplementedException();
    }
}