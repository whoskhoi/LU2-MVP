using System.Data;
using System.Reflection.Metadata.Ecma335;
using Dapper;
using IndividueelProject.WebApi.Models;

namespace IndividueelProject.WebApi.Repositories
{
    public class WorldRepository
    {
        private readonly IDbConnection dbConnection;
        public WorldRepository(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }
        public void CreateWorld(WorldModel worldData)
        {
            var sqlquery = @"
                INSERT INTO Worlds (Name, OwnerId)
                VALUES (@Name, @OwnerId)";
            dbConnection.Execute(sqlquery, worldData);
        }

        public void UpdateWorld(WorldModel worldData)
        {
            var sqlquery = @"
                UPDATE Worlds
                SET Name = @Name
                WHERE Id = @Id";
            dbConnection.Execute(sqlquery, worldData);
        }

        public void DeleteWorld(WorldModel worldData)
        {
            var sqlquery = @" 
                DELETE FROM Worlds  
                WHERE Id = @Id";
            dbConnection.Execute(sqlquery, worldData);

        }

        public WorldModel? GetByWorldId(int id)
        {
            var sqlquery = "SELECT * FROM Worlds WHERE Id = @Id;";
            return dbConnection.QueryFirstOrDefault<WorldModel>(sqlquery, new { Id = id });
        }

        public IEnumerable<WorldModel> GetAllWorlds()
        {
            var sqlquery = "SELECT * FROM Worlds";  
            return dbConnection.Query<WorldModel>(sqlquery);
            
        }
    }
}
