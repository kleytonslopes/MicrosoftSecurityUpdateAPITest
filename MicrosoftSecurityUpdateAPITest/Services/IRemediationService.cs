using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Models;

namespace MicrosoftSecurityUpdateAPITest.Services
{
    public interface IRemediationService
    {
        Task CheckAndSaveRemediation(PatchItemModel item);
    }
}
