using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Models.Templates;

namespace MicrosoftSecurityUpdateAPITest.Services
{
    public interface ICvrfdocService
    {
        Task<Cvrfdoc> GetCvrfdocFromUrlAsync(string cvrfUrl);
    }
}
