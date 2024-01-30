using Application;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dto;

namespace Presentation.Conrollers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userServes;

        public UserController(IUserService userServes)
        {
            _userServes = userServes;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            return Json(await _userServes.UserCreateServiceAsync(userDto.name, userDto.moneyAmount));
        }
    }
}