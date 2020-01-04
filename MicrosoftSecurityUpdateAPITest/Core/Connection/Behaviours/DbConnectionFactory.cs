using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Core.Connection.Behaviours
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private bool isDisposed;

        private MySqlConnection connection = null;

        public DbConnectionFactory()
        {
            connection = new MySqlConnection(Globals.ConnectionString);
        }

        public void CloseConnection()
        {
            if (connection != null)
                connection.Close();
        }

        public void OpenConnection()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Open)
                connection.Open();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void Dispose()
        {
            if(!isDisposed)
            {
                CloseConnection();
                connection = null;

                isDisposed = true;
            }

            GC.SuppressFinalize(this);
        }


    }
}
