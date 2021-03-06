﻿using System.Data;
using Autumn.Net.Annotation;
using Autumn.Net.Data;
using System.Data.SQLite;

namespace Autumn.Data.SQLite
{
    [Service]
    public class SQLiteService : IDataConnectionPoolService 
    {	    
        [Value("{database.connectionString:Data Source=:memory:;Version=3;New=True;}")]
        private string connectionString;

        public IDbConnection Get()
        {
            IDbConnection dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();
            return dbConnection;
        }

        public void Release(IDbConnection connection)
        {
            connection.Close();
        }

        public IDbDataParameter CreateParameter(string paramName, DbType dbType, object value)
        {
            return new SQLiteParameter(paramName, dbType) {Value = value};		    
        }
    }
}