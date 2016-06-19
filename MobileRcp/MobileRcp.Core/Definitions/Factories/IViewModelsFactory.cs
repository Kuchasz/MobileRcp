using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.ViewModels;

namespace MobileRcp.Core.Definitions.Factories
{
    public interface IViewModelsFactory
    {
        AuthorizationCompletedViewModel GetAuthorizationCompletedViewModel();
        ErrorScreenViewModel GetErrorScreenViewModel();
        LeaveStatsViewModel GetLeaveStatsViewModel();
        QrCodeGetterViewModel GetQrCodeGetterViewModel();
        SelectAuthorizationTypeViewModel GeSelectAuthorizationTypeViewModel();
        WorktimeStatsViewModel GetWorktimeStatsViewModel();
    }
}
