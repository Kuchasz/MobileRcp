using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Services;

namespace MobileRcp.Core.Definitions.Factories
{
    public interface ICoreFactory
    {
        IAuthorizationService GetAuthorizationService();
        IUserStatsService GetUserStatsService();
        ICoreNavigationService GetCoreNavigationService();
        IConvertersFactory GetConvertersFactory();
    }
}
