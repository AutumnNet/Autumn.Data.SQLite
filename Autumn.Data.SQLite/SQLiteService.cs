using System.Data;
using Autumn.Annotation;

#if __MonoCS__
using SQL = Mono.Data.Sqlite;  
#else
using SQL = System.Data.Sqlite;
#endif

namespace Autumn.Data.SQLite
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
    }}