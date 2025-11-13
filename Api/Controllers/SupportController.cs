using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase {
        [Authorize(Roles = "Curator")]
        [HttpGet("")]
        public async Task<IActionResult> GetAllSupportTickets() {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "User, Curator")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSupportTicket(string id) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "User")]
        [HttpPost("")]
        public async Task<IActionResult> Create(NewSupportTicketDto dto) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "User")]
        [HttpPut("")]
        public async Task<IActionResult> Modify(UpdateSupportTicketDto dto) {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "User, Curator")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(string id) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Curator")]
        [HttpPost("respond")]
        public async Task<IActionResult> Respond(NewSupportTicketResponseDto dto) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Curator")]
        [HttpPatch("respond")]
        public async Task<IActionResult>
            RespondAmend(UpdateSupportTicketResponseDto dto) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Curator")]
        [HttpDelete("respond")]
        public async Task<IActionResult>
            RespondDelete(DeleteSupportTicketResponseDto dto) {
            throw new NotImplementedException();
        }
    }
}