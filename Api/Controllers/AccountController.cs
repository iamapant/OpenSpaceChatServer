using Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        // // GET: api/<AccountController>
        // [HttpGet]
        // public IEnumerable<string> Get() { return new string[] { "value1", "value2" }; }
        //
        // // GET api/<AccountController>/5
        // [HttpGet("{id}")] public string Get(int id) { return "value"; }
        //
        // // POST api/<AccountController>
        // [HttpPost] public void Post([FromBody] string value) { }
        //
        // // PUT api/<AccountController>/5
        // [HttpPut("{id}")] public void Put(int id, [FromBody] string value) { }
        //
        // // DELETE api/<AccountController>/5
        // [HttpDelete("{id}")] public void Delete(int id) { }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ViewUsersWall(string id) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> EditWall(string id, WallEditDto dto) {
            throw new NotImplementedException();
        }
        
        [Authorize]
        [HttpGet("{id:guid}/info")]
        public async Task<IActionResult> GetUserInfo(string id) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPatch("{id:guid}/info")]
        public async Task<IActionResult> UpdateUserInfo(string id, UpdateUserInfoDto dto) {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}/decoration")]
        public async Task<IActionResult> GetMessageDecoration(string id) {
            throw new NotImplementedException();
        }//Return a dto that contains all message decoration: fonts, frame,...

        [Authorize]
        [HttpPatch("{id:guid}/decoration")]
        public async Task<IActionResult> UpdateMessageDecoration(string id
          , UpdateMessageDecorationDto dto) {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(DeleteUserDto dto) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Curator")]
        [HttpPost("timeout/{id:guid}")]
        public async Task<IActionResult> TimeoutUser(string id, NewTimeoutDto dto) {
            throw new NotImplementedException();
        }
        
        [Authorize(Roles = "Curator")]
        [HttpPost("timeout/{id:guid}/remove")]
        public async Task<IActionResult> RemoveTimeoutUser(string id) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "User")]
        [HttpPost("blacklist/{id:guid}")]
        public async Task<IActionResult> BlacklistUser(string id) {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "User")]
        [HttpPost("blacklist/{id:guid}/remove")]
        public async Task<IActionResult> RemoveBlacklistedUser(string id) {
            throw new NotImplementedException();
        }
    }
}