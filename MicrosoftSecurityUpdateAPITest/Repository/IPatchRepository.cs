using MicrosoftSecurityUpdateAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository
{
    public interface IPatchRepository
    {
        Task SavePatchItemAsync(PatchItemModel patchItemModel);
        Task<PatchItemModel> GetPatchItemByIdAsync(string id);
    }
}
