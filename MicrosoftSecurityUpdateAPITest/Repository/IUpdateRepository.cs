using MicrosoftSecurityUpdateAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository
{
    public interface IUpdateRepository
    {
        Task SaveUpdateItemAsync(UpdateItemModel updateItemModel);
    }
}
