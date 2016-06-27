using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class WorktimeStatsViewModel : ViewModelWithParameter<AuthorizedModel>
    {
        private readonly ICoreFactory _coreFactory;

        private DateTime _date;
        private IUserStatsService _userStatsService;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                Set(() => Date, ref _date, value);
                LoadWorktimes();
            }
        }

        private ObservableCollection<UserWorktime> _worktimes;
        public ObservableCollection<UserWorktime> Worktimes
        {
            get { return _worktimes; }
            set { Set(() => Worktimes, ref _worktimes, value); }
        }

        public WorktimeStatsViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            _coreFactory = coreFactory;
            _userStatsService = _coreFactory.GetUserStatsService();
        }

        private void LoadWorktimes()
        {
            var worktimes = _userStatsService.GetUserWorktimes(1, Date, Date.AddDays(DateTime.DaysInMonth(Date.Year, Date.Month)));
            Worktimes = new ObservableCollection<UserWorktime>(worktimes); 
        }
    }
}
