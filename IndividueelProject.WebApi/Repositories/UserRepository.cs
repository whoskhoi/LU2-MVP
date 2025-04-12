using System.Data;
using Dapper;
using System.Reflection;
using IndividueelProject.WebApi.Models;
using Azure.Identity;

namespace IndividueelProject.WebApi.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnection dbConnection;
        public UserRepository(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }
        public void CreateUser(UserModel data)
        {
            var sqlquery = @"
                INSERT INTO Users (Email, PasswordHash)  
                VALUES (@Email, @PasswordHash)";
            dbConnection.Execute(sqlquery, data);
        }

        public UserModel? GetByEmail(string email)
        {
            var sqlquery = "SELECT * FROM Users WHERE Email = @Email;";
            return dbConnection.QueryFirstOrDefault<UserModel>(sqlquery, new { Email = email });
        }
    }
}
