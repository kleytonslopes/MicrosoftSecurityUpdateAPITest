using MicrosoftSecurityUpdateAPITest.Core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Dapper;

namespace MicrosoftSecurityUpdateAPITest.Core
{
    public class QueryFactory : IDisposable
    {
        private bool isDisposed;
        private string _query;

        private IDbConnectionFactory dbConnectionFactory;
        private MySqlConnection connection;
        private MySqlCommand command;
        private object parameters;

        public QueryFactory(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            connection = dbConnectionFactory.GetConnection();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            InitializeCommand();
        }
        
        public async Task ExecuteAsync()
        {
            ValidateQuery();
            await connection.ExecuteAsync(_query, parameters);
        }

        public async Task<T> SelectFirstOrDefaultAsync<T>()
        {
            ValidateQuery();

            T result = await connection.QueryFirstOrDefaultAsync<T>(_query, parameters);

            if (result == null)
                return default(T);

            return result;
        }

        public async Task<IEnumerable<T>> SelectListAsync<T>()
        {
            ValidateQuery();

            IEnumerable<T> result = await connection.QueryAsync<T>(_query, parameters);

            if (result == null)
                return default(IEnumerable<T>);

            return result;
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
        public void AddParameter(string name, object value, MySqlDbType dbType)
        {
            if (isDisposed)
                throw new ArgumentException("Erro em AddParameter. O objeto QueryFactory foi descartado!");

            command.Parameters.Add(new MySqlParameter(name, dbType) { Value = value });
        }
        public void AddParameter(object parameters)
        {
            if (isDisposed)
                throw new ArgumentException("Erro em AddParameter. O objeto QueryFactory foi descartado!");
            this.parameters = parameters;
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
            {
                connection.Close();
                MySqlConnection.ClearPool(connection);
                connection.Dispose();
            }
        }

        private bool ValidateQuery()
        {
            if (isDisposed)
                throw new ArgumentException("Erro em ValidateQuery. O objeto QueryFactory foi descartado!");

            if (string.IsNullOrWhiteSpace(_query))
                throw new ArgumentException("Erro em ValidateQuery. A query string estava vazia!");

            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                return true;

            throw new ArgumentException("Erro em ValidateQuery. A conexão estava fechada!");
        }
        private void InitializeCommand()
        {
            command = new MySqlCommand();
            command.Connection = connection;
        }
    }
}
