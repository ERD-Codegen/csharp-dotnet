using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Realworlddotnet.Api.Models;
using Realworlddotnet.Core.Dto;
using Realworlddotnet.Core.Services.Interfaces;

namespace Realworlddotnet.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        public UserController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpGet]
        public async Task<ActionResult<UserEnvelope<UserDto>>> GetUser(CancellationToken cancellationToken)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userHandler.GetAsync(username, cancellationToken);
            return Ok(new UserEnvelope<UserDto>(user));
        }

        [HttpPut]
        public async Task<ActionResult<UserEnvelope<UserDto>>> UpdateUser(
            RequestEnvelope<UserEnvelope<UpdatedUserDto>> request, CancellationToken cancellationToken)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userHandler.UpdateAsync(username, request.Body.User, cancellationToken);

            return Ok(new UserEnvelope<UserDto>(user));
        }
    }
}
