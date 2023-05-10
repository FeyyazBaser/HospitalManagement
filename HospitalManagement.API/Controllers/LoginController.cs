using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;
        public LoginController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;

        }
        [HttpPost("~/api/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (await _authRepository.UserExist(registerDto.UserName))
            {
                ModelState.AddModelError("UserName", "Username already exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                Username = registerDto.UserName,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
            };
            var createdUser = await _authRepository.Register(user, registerDto.Password);

            return StatusCode(201);

        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authRepository.Login(loginDto.UserName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);

        }
    }
}
