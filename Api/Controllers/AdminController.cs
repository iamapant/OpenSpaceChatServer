using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : ControllerBase {
        [HttpGet("settings")]
        public IActionResult GetSettings() {
            throw new NotImplementedException();
        }
        
        [HttpPatch("settings")]
        public IActionResult SetSettings(AdminSettingsDto dto) {
            throw new NotImplementedException();
        }

        [HttpPost("add/curator")]
        public async Task<IActionResult> CreateCuratorAccount(NewUserDto dto) {
            throw new NotImplementedException();
        }

        [HttpPost("add/user")]
        public async Task<IActionResult> CreateUserAccount(NewUserDto dto) {
            throw new NotImplementedException();
        }

        [HttpDelete("remove/curator")]
        public async Task<IActionResult> CloseCuratorAccount(RemoveUserDto dto) {
            throw new NotImplementedException();
        }
        
        [HttpDelete("remove/user")]
        public async Task<IActionResult> CloseUserAccount(RemoveUserDto dto) {
            throw new NotImplementedException();
        }
    }
}