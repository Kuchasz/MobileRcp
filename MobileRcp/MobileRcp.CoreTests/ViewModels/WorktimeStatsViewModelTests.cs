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
    public class WorktimeStatsViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }

        public WorktimeStatsViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();

            CoreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<AuthorizedModel>().
                Returns(new AuthorizedModel()
                {
                    AuthorizationData = new UserAuthorizationData()
                    {
                        UserIdent = 1
                    }
                });
        }

        [Test]
        public void ShouldInitializeChildViewModels()
        {
            var model = new WorktimeStatsViewModel(CoreFactory);

            Assert.NotNull(model.WorktimeMonths);
        }

        [Test]
        public void ShouldInitializeChildViewModelsWithPropertMonthDate()
        {
            var model = new WorktimeStatsViewModel(CoreFactory);

            Assert.NotNull(model.WorktimeMonths);

            for (int i = 0; i < model.WorktimeMonths.Count; i++)
            {
                Assert.AreEqual(DateTime.Now.AddMonths(-i).ToShortDateString(), model.WorktimeMonths[i].Date.ToShortDateString());
            }
        }
    }
}
