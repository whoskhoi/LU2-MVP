using System.Data;
using Dapper;
using System.Reflection;
using IndividueelProject.WebApi.Models;
using Azure.Identity;


namespace IndividueelProject.WebApi.Repositories
{
    public class ObjectRepository
    {
        private readonly IDbConnection dbConnection;
        public ObjectRepository(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }

        public void CreateObject(ObjectModel objectData)
        {
            var sqlquery = @"
                INSERT INTO Objects (Type, PositionX, PositionY)
                VALUES (@Type, @PositionX, @PositionY)";
            dbConnection.Execute(sqlquery, objectData);
        }

        public void UpdateObject(ObjectModel objectData)
        {
            var sqlquery = @"
                UPDATE Objects
                SET PositionX = @PositionX, PositionY = @PositionY
                WHERE Id = @Id";
            dbConnection.Execute(sqlquery, objectData);
        }

        public void DeleteObject(ObjectModel objectData)
        {
            var sqlquery = @"
                DELETE FROM Objects
                WHERE Id = @Id";
            dbConnection.Execute(sqlquery, objectData);
        }

        public ObjectModel? GetByObject (int id)
        {
            var sqlquery = "SELECT * FROM Objects WHERE Id = @Id;";
            return dbConnection.QueryFirstOrDefault<ObjectModel>(sqlquery, new { Id = id });
        }
                
        public IEnumerable<ObjectModel> GetAllObjects(int worldId)
        {
            var sqlquery = "SELECT * FROM Objects WHERE WorldId = @WorldId";
            return dbConnection.Query<ObjectModel>(sqlquery);
        }
    }
}
