using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Core.Connection
{
    public interface IDbConnectionFactory : IDisposable
    {
        MySqlConnection GetConnection();
    }
}
