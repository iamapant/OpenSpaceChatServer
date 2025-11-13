using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase {
        
        // Receiving new messages are delegated to regional servers 
        // [HttpPost("public")]
        // public async Task<IActionResult> SendPublicMessage(PublicMessageDto dto) {
        //     throw new NotImplementedException();
        // }
        //
        // [HttpPost("private")]
        // public async Task<IActionResult> SendPrivateMessage(PrivateMessageDto dto) {
        //     throw new NotImplementedException();
        // }
        
        // [HttpDelete("public/remove/{id}")]
        // public async Task<IActionResult> RemovePublicMessage(string id) {}
        //
        // [HttpDelete("private/remove/{id}")]
        // public async Task<IActionResult> RemovePrivateMessage(string id) {}
        //
        // [HttpPut("public/archive")]
        // public async Task<IActionResult> ArchivePublicMessage(ArchivePublicMessageDto dto) {}


        [HttpPut("private/archive")]
        public async Task<IActionResult> ArchivePrivateMessage(
            ArchivePrivateMessageDto dto) {
            throw new NotImplementedException();
        }

        [HttpPut("public/archive/remove/{messageId}")]
            public async Task<IActionResult> UnarchivePublicMessage(string messageId) {
                throw new NotImplementedException();
        }

        [HttpPut("private/archive/remove/{messageId}")]
            public async Task<IActionResult> UnarchivePrivateMessage(string messageId) {
                throw new NotImplementedException();
        }
        
        [HttpPut("pin/{inboxId}/{messageId}")]
            public async Task<IActionResult> PinMessage(string inboxId, string messageId) {
                throw new NotImplementedException();
        }
        
        [HttpPut("unpin/{inboxId}/{messageId}")]
            public async Task<IActionResult> UnpinMessage(string inboxId, string messageId) {
                throw new NotImplementedException();
        }
    }
}