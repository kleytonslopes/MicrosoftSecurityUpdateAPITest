using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest
{
    internal static class Globals
    {
        private static int _minutes;
        private static string _connectionString;

        public const string HTTP_CLIENT_MICROSOFT_API = "msrc_microsoft";
        public static int Minutes => _minutes;
        public static string ConnectionString => _connectionString;

        /// <summary>
        /// Checar API em minutos
        /// </summary>
        /// <param name="minutes"></param>
        internal static void SetTimeCheckPatch(int minutes)
        {
            _minutes = minutes * 60000;
        }
        /// <summary>
        /// Checar API em minutos
        /// </summary>
        /// <param name="minutes"></param>
        internal static void SetTimeCheckPatch(string minutes)
        {
            SetTimeCheckPatch(Convert.ToInt32(minutes));
        }

        internal static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
