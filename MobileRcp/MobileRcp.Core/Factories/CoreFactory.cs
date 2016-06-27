using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Services;

namespace MobileRcp.Core.Factories
{
    public class CoreFactory : ICoreFactory
    {
        private readonly ICoreNavigationService _platformSpecificNavigation;
        private IAuthorizationService _authorizationService;
        private IUserStatsService _userStatsService;

        public CoreFactory(ICoreNavigationService platformSpecificNavigation)
        {
            _platformSpecificNavigation = platformSpecificNavigation;
        }

        public IAuthorizationService GetAuthorizationService()
        {
            return _authorizationService ?? (_authorizationService = new DummyAuthorizationService());
        }

        public IUserStatsService GetUserStatsService()
        {
            return _userStatsService ?? (_userStatsService = new DummyUserStatsService());
        }

        public ICoreNavigationService GetCoreNavigationService()
        {
            return _platformSpecificNavigation;
        }
    }
}
