using Cards.Application;
using Cards.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cards.Models.Dto;

namespace Cards.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var token =  await _userService.Login(user);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid Payload");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
