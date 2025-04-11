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
            var sqlquery = "INSERT INTO Users (Email, Password) VALUES (@Email, @Password);";
            dbConnection.Execute(sqlquery, model);
            return Ok("Registration succesful");
        }    
    }
}
