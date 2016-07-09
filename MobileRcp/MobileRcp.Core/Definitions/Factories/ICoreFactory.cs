using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Services;

namespace MobileRcp.Core.Definitions.Factories
{
    //Review: this interface is a godlike object, it knows way too much. Use any IoC framework to inject dependencies instead.
    //Do not pass Dependency Injection Container to application-level classes (this factory is passed to ViewModels)
    //Due to this fact any viewmodel has ability to access eg userStatsService, even if should not.
    //Each time any service, factory, etc class will be added you would have to get back into this class and change its definition
    //Or if you change signature of one of this factory methods every class that rely on eg. GetUserStatsService(); will have to be fixed.
    public interface ICoreFactory
    {
        IAuthorizationService GetAuthorizationService();
        IUserStatsService GetUserStatsService();
        ICoreNavigationService GetCoreNavigationService();
        IConvertersFactory GetConvertersFactory();
    }
}
