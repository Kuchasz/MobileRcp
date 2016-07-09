using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    //Review: I would place this class in Prabez.MobileRcp.Application.Authorization.ViewModels
    public class AuthorizationCompletedViewModel : ViewModelWithParameter<AuthorizedModel>
    {
        private readonly ICoreFactory _coreFactory;

        private string _endMessage;
        public string EndMessage
        {
            get { return _endMessage; }
            set { Set(() => EndMessage, ref _endMessage, value); }
        }

        public RelayCommand EndAuthorizationCommand { get; private set; }
        public RelayCommand ShowWorktimeCommand { get; private set; }
        public RelayCommand ShowLeaveStatsCommand { get; private set; }

        public AuthorizationCompletedViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            _coreFactory = coreFactory;

            EndAuthorizationCommand = new RelayCommand(coreFactory.GetCoreNavigationService().GoToQrCodeGetter);
            ShowWorktimeCommand = new RelayCommand(() => coreFactory.GetCoreNavigationService().GoToWorktimeStats(ViewModelParameter));
            ShowLeaveStatsCommand = new RelayCommand(() => coreFactory.GetCoreNavigationService().GoToLeaveStats(ViewModelParameter));
        }
    }
}
