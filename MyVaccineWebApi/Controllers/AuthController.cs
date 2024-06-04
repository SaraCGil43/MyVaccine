using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using MyVaccineWebApi.Dtos;
using MyVaccineWebApi.Literals;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Depency Injections
        private readonly IUserService _userService;

        //Constructor con inyección de dependencias 
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var response = await _userService.AddUserAsync(model); 
            if(response != null && response.IsSuccess)
            {
            return Ok("User registered successfully");
            }
            else
            {
                return BadRequest(response);
            }       
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var response = await _userService.Login(model);
            if (response != null && response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
        }
        [Authorize] //Metodo que es protegido, sin estar autenticado el usuario no ingresa.
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            //Acciones recomendadas en los controladores, responsabilidad unica.

            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var response = await _userService.RefreshToken(claimsIdentity.Name);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }

        }

        [Authorize] //Metodo que es protegido, sin estar autenticado el usuario no ingresa.
        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            //Acciones recomendadas en los controladores, responsabilidad unica.

            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var response = await _userService.GetUserInfo(claimsIdentity.Name);

                return Ok(response);
          

        }
    }
}