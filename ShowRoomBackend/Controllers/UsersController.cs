using Microsoft.AspNetCore.Mvc;
using SR.Core.Utilities.Results;
using SR.Entities.Concrete.RequestModels.Users;
using SR.Entities.Concrete.ViewModels.User;
using IResult = SR.Core.Utilities.Results.IResult;


namespace SR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("GetUser")]
        [ProducesResponseType(typeof(IDataResult<UserViewModel>), 200)]
        public async Task<IActionResult> GetUser(int userId)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpGet("GetListOfUsers")]
        [ProducesResponseType(typeof(IDataResult<List<UserViewModel>>), 200)]
        public async Task<IActionResult> GetListOfUsers()
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpPost("RegisterUser")]
        [ProducesResponseType(typeof(IResult), 200)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequsetModel userRegisterRequestModel)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(typeof(IResult), 200)]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestModel userUpdateRequestModel)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(typeof(IResult), 200)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }
    }
}
