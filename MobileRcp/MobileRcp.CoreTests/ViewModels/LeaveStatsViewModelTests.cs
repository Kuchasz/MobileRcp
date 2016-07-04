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
    public class LeaveStatsViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }

        public LeaveStatsViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();
        }

        [Test]
        public void ShouldGetLeavesLeft()
        {
            var authorizedModel = new AuthorizedModel()
            {
                AuthorizationData = new UserAuthorizationData()
                {
                    UserIdent = 1
                }
            };

            var leavesLeft = 10;

            CoreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<AuthorizedModel>().
                Returns(authorizedModel);

            CoreFactory.
                GetUserStatsService().
                GetUserLeavesLeft(authorizedModel.AuthorizationData.UserIdent).
                Returns(leavesLeft);

            var viewModel = new LeaveStatsViewModel(CoreFactory);

            CoreFactory.
                GetUserStatsService().
                Received().
                GetUserLeavesLeft(authorizedModel.AuthorizationData.UserIdent);

            Assert.AreEqual(leavesLeft, viewModel.LeavesLeft);
        }

        [Test]
        public void ShouldGetLeavesCards()
        {
            var authorizedModel = new AuthorizedModel()
            {
                AuthorizationData = new UserAuthorizationData()
                {
                    UserIdent = 1
                }
            };

            CoreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<AuthorizedModel>().
                Returns(authorizedModel);

            new LeaveStatsViewModel(CoreFactory);

            CoreFactory.
                GetUserStatsService().
                Received().
                GetUserLeavesCards(authorizedModel.AuthorizationData.UserIdent);
        }

        [Test]
        public void ShouldConvertLeavesCards()
        {
            var authorizedModel = new AuthorizedModel()
            {
                AuthorizationData = new UserAuthorizationData()
                {
                    UserIdent = 1
                }
            };

            var leavesCards = new []
            {
                new LeaveCard()
            };

            CoreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<AuthorizedModel>().
                Returns(authorizedModel);

            CoreFactory.
                GetUserStatsService().
                GetUserLeavesCards(authorizedModel.AuthorizationData.UserIdent).
                Returns(leavesCards);

            var viewModel = new LeaveStatsViewModel(CoreFactory);

            CoreFactory.
                GetConvertersFactory().
                GetLeaveCardConverter().
                Received().
                Convert(leavesCards);

            Assert.NotNull(viewModel.LeavesCards);
        }

        [Test]
        public void ShouldGoBack()
        {
            var authorizedModel = new AuthorizedModel()
            {
                AuthorizationData = new UserAuthorizationData()
                {
                    UserIdent = 1
                }
            };

            CoreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<AuthorizedModel>().
                Returns(authorizedModel);

            var viewModel = new LeaveStatsViewModel(CoreFactory);

            viewModel.GoBackCommand.Execute(null);

            CoreFactory.
                GetCoreNavigationService().
                Received().
                GoToAuthorizationCompleted(authorizedModel);
        }
    }
}
