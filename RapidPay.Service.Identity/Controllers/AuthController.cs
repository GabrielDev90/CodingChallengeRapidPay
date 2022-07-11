using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Service.Identity.Application;
using RapidPay.Service.Identity.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace RapidPay.Service.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthFacade _authFacade;

        public AuthController(IAuthFacade authFacade)
        {
            _authFacade = authFacade;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _authFacade.CreateUser(createUserDto);
            return StatusCode(result.StatusCode, result);
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var result = await _authFacade.SignIn(signInDto);

            return StatusCode(result.StatusCode, result);
        }
    }
}
