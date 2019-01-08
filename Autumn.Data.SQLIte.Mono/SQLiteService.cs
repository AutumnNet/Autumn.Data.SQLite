using System.Data;
using Autumn.Net.Annotation;
using Autumn.Net.Data;
using SQL = Mono.Data.Sqlite;  

namespace Autumn.Data.SQLite.Mono
{
    [Service]
    public class SQLiteService : IDataConnectionPoolService 
    {	    
        [Value("{database.connectionString:Data Source=:memory:;Version=3;New=True;}")]
        private string connectionString;

        public IDbConnection Get()
        {
            IDbConnection dbConnection = new SQL.SqliteConnection(connectionString);
            dbConnection.Open();
            return dbConnection;
        }

        public void Release(IDbConnection connection)
        {
            connection.Close();
        }

        public IDbDataParameter CreateParameter(string paramName, DbType dbType, object value)
        {
            return new SQL.SqliteParameter(paramName, dbType) {Value = value};		    
        }
    }
}