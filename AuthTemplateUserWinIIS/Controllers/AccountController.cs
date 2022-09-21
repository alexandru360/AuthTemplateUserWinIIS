using AuthTemplateUserWinIIS.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Services;

namespace AuthTemplateUserWinIIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/account
        [HttpGet]
        //[AllowAnonymous]
        public string Get()
        {
            return AccountHelper.GetWinAuthAccount(HttpContext);
        }


        [HttpGet("get-token")]
        public IActionResult GetToken()
        {
            var response = _userService.AuthenticateResponse();

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("authorized-operation")]
        public IActionResult GetAuthorizedOperation()
        {
            return Ok("You are authorized to read this text!");
        }
    }
}