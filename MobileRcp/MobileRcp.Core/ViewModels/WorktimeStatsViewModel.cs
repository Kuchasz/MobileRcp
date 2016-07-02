using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Extensions;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class WorktimeStatsViewModel : ViewModelWithParameter<AuthorizedModel>
    {
        private readonly ICoreFactory _coreFactory;
        private ObservableCollection<WorktimeStatsMonthViewModel> _worktimeMonths;
        public ObservableCollection<WorktimeStatsMonthViewModel> WorktimeMonths
        {
            get { return _worktimeMonths; }
            set { Set(() => WorktimeMonths, ref _worktimeMonths, value); }
        }


        public RelayCommand GoBackCommand { get; private set; }

        public WorktimeStatsViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            _coreFactory = coreFactory;

            GoBackCommand = new RelayCommand(GoBack);

            InitializeWorktimeMonths(DateTime.Now, 3);
        }

        private void GoBack()
        {
            _coreFactory.
                GetCoreNavigationService().
                GoToAuthorizationCompleted(ViewModelParameter);
        }

        private void InitializeWorktimeMonths(DateTime startDate, int howMany)
        {
            WorktimeMonths = new ObservableCollection<WorktimeStatsMonthViewModel>();

            for (int i = 0; i < howMany; i++)
            {
                var viewModel = new WorktimeStatsMonthViewModel(_coreFactory)
                {
                    Date = startDate.AddMonths(-i),
                    UserIdent = ViewModelParameter.AuthorizationData.UserIdent
                };

                WorktimeMonths.Add(viewModel);
            }
        }
    }
}
