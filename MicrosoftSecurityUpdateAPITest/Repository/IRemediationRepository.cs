using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Models;

namespace MicrosoftSecurityUpdateAPITest.Repository
{
    public interface IRemediationRepository
    {
        Task SaveRemediationAsync(RemediationModel remediationModel);
        Task<RemediationModel> GetRemediationByIdAsync(string remediationId, string patchItemid);
    }
}
