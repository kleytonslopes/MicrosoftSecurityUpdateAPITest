using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Mappings.Utils
{
    public static class MappingSystem
    {
        private static bool isRegistered;

        public static void Register()
        {
            if (isRegistered)
                return;

            Dapper.FluentMap.FluentMapper.Initialize(config => 
            {
                config.AddMap(new PatchItemMapping());
                config.AddMap(new RemediationMapping());
            });

            isRegistered = true;
        }
    }
}
