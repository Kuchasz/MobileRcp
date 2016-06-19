using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.ViewModels;

namespace MobileRcp.Core.Factories
{
    public class ViewModelsFactory : IViewModelsFactory
    {
        private readonly ICoreFactory _coreFactory;

        public ViewModelsFactory(ICoreFactory coreFactory)
        {
            _coreFactory = coreFactory;
        }

        public AuthorizationCompletedViewModel GetAuthorizationCompletedViewModel()
        {
            return new AuthorizationCompletedViewModel(_coreFactory);
        }

        public ErrorScreenViewModel GetErrorScreenViewModel()
        {
            return new ErrorScreenViewModel(_coreFactory);
        }

        public LeaveStatsViewModel GetLeaveStatsViewModel()
        {
            return new LeaveStatsViewModel(_coreFactory);
        }

        public QrCodeGetterViewModel GetQrCodeGetterViewModel()
        {
            return new QrCodeGetterViewModel(_coreFactory);
        }

        public SelectAuthorizationTypeViewModel GeSelectAuthorizationTypeViewModel()
        {
            return new SelectAuthorizationTypeViewModel(_coreFactory);
        }

        public WorktimeStatsViewModel GetWorktimeStatsViewModel()
        {
            return new WorktimeStatsViewModel(_coreFactory);
        }
    }
}
