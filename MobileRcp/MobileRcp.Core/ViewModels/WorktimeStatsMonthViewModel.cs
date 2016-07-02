using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Extensions;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class WorktimeStatsMonthViewModel : ViewModelBase
    {
        private readonly ICoreFactory _coreFactory;

        private IUserStatsService _userStatsService;
        private IValueConverter<IEnumerable<UserWorktime>, IEnumerable<UserWorktimeToDisplay>> _worktimeConverter;

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                Set(() => Date, ref _date, value);

                GetDataForMonth();
            }
        }

        public int UserIdent { get; set; }

        public string Month => GetMonthNameFromDate();
        public string TotalWorktime => GetTotalWorktime();
        public string TotalExpectedWorktime => GetTotalExpectedWorktime();

        private ObservableCollection<UserWorktimeToDisplay> _worktimes;
        private TimeSpan _userTotalWorktime;
        private TimeSpan _userExpectedTotalWorktime;

        public ObservableCollection<UserWorktimeToDisplay> Worktimes
        {
            get { return _worktimes; }
            set { Set(() => Worktimes, ref _worktimes, value); }
        }

        public WorktimeStatsMonthViewModel(ICoreFactory coreFactory)
        {
            _coreFactory = coreFactory;
            _userStatsService = _coreFactory.GetUserStatsService();
            _worktimeConverter = _coreFactory.GetConvertersFactory().GetWorktimeToDisplayConverter();
        }

        private void GetDataForMonth()
        {
            var worktimes = _userStatsService.GetUserWorktimes(UserIdent, Date, Date.AddDays(DateTime.DaysInMonth(Date.Year, Date.Month)));
            Worktimes = new ObservableCollection<UserWorktimeToDisplay>(_worktimeConverter.Convert(worktimes).OrderByDescending(n => Convert.ToInt32(n.Day)));

            _userTotalWorktime = _userStatsService.GetUserTotalWorktime(UserIdent, Date, Date.AddDays(DateTime.DaysInMonth(Date.Year, Date.Month)));
            _userExpectedTotalWorktime = _userStatsService.GetUserExpectedTotalWorktime(UserIdent, Date, Date.AddDays(DateTime.DaysInMonth(Date.Year, Date.Month)));
        }

        private string GetMonthNameFromDate()
        {
            return Date.ToString("MMMM", new CultureInfo("pl-PL")).FirstLetterToUpper();
        }

        private string GetTotalWorktime()
        {
            return $"{_userTotalWorktime.TotalHours.ToString("####")}:{_userTotalWorktime.Minutes.ToString("00.##")}";
        }

        private string GetTotalExpectedWorktime()
        {
            return $"{_userExpectedTotalWorktime.TotalHours.ToString("####")}:{_userExpectedTotalWorktime.Minutes.ToString("00.##")}";
        }
    }
}
