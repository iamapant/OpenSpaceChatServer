using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> ClearSession() {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto) {
            throw new NotImplementedException();
        }
        
        // Ask user to enter personal information and send email w/ token and secret to set up new password
        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost("change-password/{token}")]
        public async Task<IActionResult> ChangeResetPassword(string token
          , ChangePasswordDto dto) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshRefreshToken(RefreshDto dto) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost("access")]
        public async Task<IActionResult> RefreshJwtToken(RefreshJwtDto dto) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "User")]
        [HttpPost("deactivate/{id}")]
        public async Task<IActionResult> DeactivateUser(string id) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "User")]
        [HttpPost("reactivate/{id}")]
        public async Task<IActionResult> ReactivateUser(string id) {
            throw new NotImplementedException();
        }
    }
    }