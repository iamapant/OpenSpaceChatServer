using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Curator")]
    public class CuratorController : ControllerBase {
        [HttpGet("settings")]
        public IActionResult GetSettings() { throw new NotImplementedException(); }

        [HttpPatch("settings")]
        public IActionResult SetSettings(UpdateAdminSettingsDto dto) {
            throw new NotImplementedException();
        }

        //Landmark
        [AllowAnonymous]
        [HttpGet("landmark")]
        public async Task<IActionResult> GetLandmarks() {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("landmark/{id:guid}")]
        public async Task<IActionResult> GetLandmark(string id) {
            throw new NotImplementedException();
        }

        [HttpPost("landmark")]
        public async Task<IActionResult> AddLandmark(NewLandmarkDto dto) {
            throw new NotImplementedException();
        }

        [HttpPut("landmark")]
        public async Task<IActionResult> UpdateLandmark(UpdateLandmarkDto dto) {
            throw new NotImplementedException();
        }

        [HttpDelete("landmark/{id:guid}")]
        public async Task<IActionResult> RemoveLandmark(DeleteLandmarkDto dto) {
            throw new NotImplementedException();
        }

        //Timeout
        [HttpGet("timeout")]
        public async Task<IActionResult> GetTimeouts() {
            throw new NotImplementedException();
        }

        [HttpGet("timeout/{userId:guid}")]
        public async Task<IActionResult> GetTimeout(string userId) {
            throw new NotImplementedException();
        }

        [HttpPost("timeout")]
        public async Task<IActionResult> AddTimeout(NewTimeoutDto dto) {
            throw new NotImplementedException();
        }

        [HttpPut("timeout")]
        public async Task<IActionResult> UpdateTimeout(UpdateTimeoutDto dto) {
            throw new NotImplementedException();
        }

        [HttpDelete("timeout")]
        public async Task<IActionResult> RemoveTimeout(RemoveTimeoutDto dto) {
            throw new NotImplementedException();
        }
    }
}