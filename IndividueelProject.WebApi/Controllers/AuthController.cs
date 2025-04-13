using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using IndividueelProject.WebApi.Models;
using IndividueelProject.WebApi.Dtos;
using IndividueelProject.WebApi.Repositories;
using BCrypt.Net;


namespace IndividueelProject.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository userRepo;
        public AuthController(UserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        // POST /api/auth/register
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // check if email is taken
                var existingEmail = userRepo.GetByEmail(registerDto.Email);
                if (existingEmail != null)
                    return Conflict(new { message = "Email is already taken" });

                // password hashing
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

                var user = new UserModel
                {
                    Email = registerDto.Email,
                    PasswordHash = hashPassword
                };

                userRepo.CreateUser(user);
                return Ok(new { message = "Registration succesful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while registering." + ex);
            }
        }

        // POST api/auth/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginUserDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var email = userRepo.GetByEmail(loginDto.Email);
            if (email == null)
                return Unauthorized( new { message = "Invalid credentials" });


            bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, email.PasswordHash);
            if (!isValidPassword)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { message = "Login succesful" });
        }

        

    }
}
