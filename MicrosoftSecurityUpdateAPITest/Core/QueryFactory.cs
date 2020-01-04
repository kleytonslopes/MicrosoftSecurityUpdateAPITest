using MicrosoftSecurityUpdateAPITest.Core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace MicrosoftSecurityUpdateAPITest.Core
{
    public class QueryFactory : IDisposable
    {
        private bool isDisposed;
        private string _query;

        private IDbConnectionFactory dbConnectionFactory;
        private MySqlConnection connection;
        private MySqlCommand command;

        public QueryFactory(IDbConnectionFactory dbConnectionFactory)
        {
            //dbConnectionFactory = serviceProvider.GetService<IDbConnectionFactory>();
            this.dbConnectionFactory = dbConnectionFactory;
            connection = dbConnectionFactory.GetConnection();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            InitializeCommand();
        }

        private void InitializeCommand()
        {
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void SetQuery(string query)
        {
            if (isDisposed)
                throw new ArgumentException("Erro em SetQuery. O objeto QueryFactory foi descartado!");

            _query = query;

            if (command == null)
                InitializeCommand();

            command.CommandText = _query;
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                CloseConnection();

                connection = null;

                command.Dispose();
                command = null;

                isDisposed = true;
            }
        }

        private void CloseConnection()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
