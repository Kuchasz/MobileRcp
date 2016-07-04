using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class LeaveStatsViewModel : ViewModelWithParameter<AuthorizedModel>
    {
        private readonly ICoreFactory _coreFactory;

        private int _leavesLeft;
        public int LeavesLeft
        {
            get { return _leavesLeft; }
            set { Set(() => LeavesLeft, ref _leavesLeft, value); }
        }

        private ObservableCollection<LeaveCardToDisplay> _leavesCards;
        public ObservableCollection<LeaveCardToDisplay> LeavesCards
        {
            get { return _leavesCards; }
            set { Set(() => LeavesCards, ref _leavesCards, value); }
        }

        public RelayCommand GoBackCommand { get; private set; }
        public RelayCommand EndAuthorizationCommand { get; set; }

        public LeaveStatsViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            _coreFactory = coreFactory;

            GoBackCommand = new RelayCommand(GoBack);
            EndAuthorizationCommand = new RelayCommand(EndAuthorization);

            GetData();
        }

        private void GetData()
        {
            LeavesLeft = _coreFactory.
                GetUserStatsService().
                GetUserLeavesLeft(ViewModelParameter.AuthorizationData.UserIdent);

            var leavesCards = _coreFactory.
                GetUserStatsService().
                GetUserLeavesCards(ViewModelParameter.AuthorizationData.UserIdent);

            var leavesCardsToDisplay = _coreFactory.
                GetConvertersFactory().
                GetLeaveCardConverter().
                Convert(leavesCards);

            LeavesCards = new ObservableCollection<LeaveCardToDisplay>(leavesCardsToDisplay);
        }

        private void GoBack()
        {
            _coreFactory.
                GetCoreNavigationService().
                GoToAuthorizationCompleted(ViewModelParameter);
        }

        private void EndAuthorization()
        {
            _coreFactory.
                GetCoreNavigationService().
                GoToQrCodeGetter();
        }
    }
}
