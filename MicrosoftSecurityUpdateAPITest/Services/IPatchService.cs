﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Models;

namespace MicrosoftSecurityUpdateAPITest.Services
{
    public interface IPatchService
    {
        bool NotProcessing { get; }

        /// <summary>
        /// Checa e salva atualizações
        /// </summary>
        /// <returns></returns>
        Task CheckAndSavePatchesAsync();
    }
}
