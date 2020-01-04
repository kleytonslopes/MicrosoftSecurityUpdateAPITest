using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Services
{
    public interface IUpdatesService
    {
        bool NotProcessing { get; }

        /// <summary>
        /// Checa e salva atualizações
        /// </summary>
        /// <returns></returns>
        Task CheckAndSaveUpdatesAsync();
    }
}
