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
    public class AuthorizationCompletedViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }
        public AuthorizedModel AuthorizedModel { get; set; }

        public AuthorizationCompletedViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();

            AuthorizedModel = new AuthorizedModel()
            {
                EntryType = EntryType.NormalIn,
                Date = DateTime.Now,
                AuthorizationData = new UserAuthorizationData()
                {
                    UserIdent = 1,
                    UserAuthorizationToken = "token"
                }
            };

            CoreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<AuthorizedModel>().
                Returns(AuthorizedModel);
        }

        [Test]
        public void EndAuthorizationShouldOpenQrCodeGetter()
        {            
            var viewModel = new AuthorizationCompletedViewModel(CoreFactory);

            viewModel.
                EndAuthorizationCommand.
                Execute(null);

            CoreFactory.
                GetCoreNavigationService().
                Received().
                GoToQrCodeGetter();
        }

        [Test]
        public void ShowWorktimeCommandShouldOpenScreenWithStats()
        {
            var viewModel = new AuthorizationCompletedViewModel(CoreFactory);

            viewModel.
                ShowWorktimeCommand.
                Execute(null);

            CoreFactory.
                GetCoreNavigationService().
                Received().
                GoToWorktimeStats(AuthorizedModel);
        }

        [Test]
        public void ShowLeaveCommandShouldOpenScreenWithStats()
        {
            var viewModel = new AuthorizationCompletedViewModel(CoreFactory);

            viewModel.
                ShowLeaveStatsCommand.
                Execute(null);

            CoreFactory.
                GetCoreNavigationService().
                Received().
                GoToLeaveStats(AuthorizedModel);

        }

    }
}
