﻿using System;
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
        public const string HTTP_CLIENT_MICROSOFT_API_XML = "msrc_microsoft_xml";
        public static int Minutes => _minutes;
        public static string ConnectionString => _connectionString;

        /// <summary>
        /// Checar API em minutos
        /// </summary>
        /// <param name="minutes"></param>
        internal static void SetTimeCheckUpdates(int minutes)
        {
            _minutes = minutes * 60000;
        }
        /// <summary>
        /// Checar API em minutos
        /// </summary>
        /// <param name="minutes"></param>
        internal static void SetTimeCheckUpdates(string minutes)
        {
            SetTimeCheckUpdates(Convert.ToInt32(minutes));
        }

        internal static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}