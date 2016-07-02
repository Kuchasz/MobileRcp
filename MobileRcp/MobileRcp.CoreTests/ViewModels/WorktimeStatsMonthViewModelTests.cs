using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;
using MobileRcp.Core.ViewModels;
using NSubstitute;
using NUnit.Framework;

namespace MobileRcp.CoreTests.ViewModels
{
    public class WorktimeStatsMonthViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }

        public WorktimeStatsMonthViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();
        }

        [Test]
        public void ShouldGetOrderedDescendingByDayWorktimesWhenDateChanged()
        {
            var userIdent = 1;
            var date = new DateTime(2016,1,1);

            var worktimesToDisplay = new []
            {
                new UserWorktimeToDisplay()
                {
                    Day = "8"
                }, 
                new UserWorktimeToDisplay()
                {
                    Day = "11"
                }, 
            };

            CoreFactory.
                GetConvertersFactory().
                GetWorktimeToDisplayConverter().
                Convert(Arg.Any<IEnumerable<UserWorktime>>()).
                Returns(worktimesToDisplay);

            var viewModel = new WorktimeStatsMonthViewModel(CoreFactory);

            viewModel.Date = date;
            
            Assert.NotNull(viewModel.Worktimes);
            Assert.AreEqual("11", viewModel.Worktimes[0].Day);
            Assert.AreEqual("8", viewModel.Worktimes[1].Day);
        }

        [Test]
        public void ShouldReturnProperMonthNameWhenDateChanged()
        {
            var date = new DateTime(2016,2,2);

            var viewModel = new WorktimeStatsMonthViewModel(CoreFactory);

            viewModel.Date = date;

            Assert.AreEqual("Luty", viewModel.Month);
        }

        [Test]
        public void ShouldReturnProperFormattedTotalWorktimeWhenDateChanged()
        {
            var date = DateTime.Now;

            CoreFactory.
                GetUserStatsService().
                GetUserTotalWorktime(Arg.Any<int>(), date, Arg.Any<DateTime>()).
                Returns(new TimeSpan(20,0,0,0));

            var viewModel = new WorktimeStatsMonthViewModel(CoreFactory);

            viewModel.Date = date;

            Assert.AreEqual("480:00", viewModel.TotalWorktime);
        }

        [Test]
        public void ShouldReturnProperTotalExpectedworktimeWhenDateChanged()
        {
            var date = DateTime.Now;

            CoreFactory.
                GetUserStatsService().
                GetUserExpectedTotalWorktime(Arg.Any<int>(), date, Arg.Any<DateTime>()).
                Returns(new TimeSpan(60, 0, 0));

            var viewModel = new WorktimeStatsMonthViewModel(CoreFactory);

            viewModel.Date = date;

            Assert.AreEqual("60:00", viewModel.TotalExpectedWorktime);
        }
    }
}
