﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest
{
    internal static class Globals
    {
        private static int _minutes;

        public const string HTTP_CLIENT_MICROSOFT_API = "msrc_microsoft";
        public static int Minutes => _minutes;

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
    }
}
