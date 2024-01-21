using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SR.Business.Abstract;
using SR.Core.Utilities.Messages;
using SR.Core.Utilities.Results;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.RequestModels.Users;
using SR.Entities.Concrete.ViewModels.User;
using IResult = SR.Core.Utilities.Results.IResult;


namespace SR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser")]
        [Authorize]
        [ProducesResponseType(typeof(IDataResult<UserViewModel>), 200)]
        public async Task<IActionResult> GetUser(int userId)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpGet("GetListOfUsers")]
        [ProducesResponseType(typeof(IDataResult<List<UserViewModel>>), 200)]
        [Authorize]
        public async Task<IActionResult> GetListOfUsers()
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpPost("RegisterUser")]
        [ProducesResponseType(typeof(IDataResult<User>), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser([FromBody] UserRegisterRequsetModel userRegisterRequestModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status406NotAcceptable, Messages.ModelError);

            var result = await _userService.RegisterAsync(userRegisterRequestModel);
            return StatusCode(result.Code, result);
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(IDataResult<User>), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequestModel userLoginRequestModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status406NotAcceptable, Messages.ModelError);

            var result = await _userService.LoginAsync(userLoginRequestModel);
            return StatusCode(result.Code, result);
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        [ProducesResponseType(typeof(IResult), 200)]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestModel userUpdateRequestModel)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(typeof(IResult), 200)]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            return StatusCode(StatusCodes.Status200OK, Task.FromResult(0));
        }
    }
}
