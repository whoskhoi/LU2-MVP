using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using IndividueelProject.WebApi.Models;


namespace IndividueelProject.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IDbConnection dbConnection;
        public AuthController(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody]UserModel model)
        {
            var sqlquery = "INSERT INTO Users (Email, PasswordHash) VALUES (@Email, @PasswordHash);";
            dbConnection.Execute(sqlquery, model);
            return Ok("Registration succesful");
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody]UserModel model)
        {
            var sqlquery = "SELECT Id, PasswordHash FROM Users WHERE Email = @Email;";
            dbConnection.Execute(sqlquery, model);
            return Ok("Login succesful");
        }

    }
}
