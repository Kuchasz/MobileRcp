using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Exceptions;
using MobileRcp.Core.Models;
using MobileRcp.Core.ViewModels;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace MobileRcp.CoreTests.ViewModels
{
    public class QrCodeGetterViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }

        public QrCodeGetterViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();
        }

        [Test]
        public void PassQrCodeInCommandTest()
        {
            var qrCode = "testToken123";
            var receivedUserQrCode = string.Empty;

            CoreFactory.
                GetAuthorizationService().
                AuthorizeUser(Arg.Do<string>(n => receivedUserQrCode = n));


            var viewModel = new QrCodeGetterViewModel(CoreFactory);

            viewModel.GetQrCodeCommand.Execute(qrCode);


            Assert.AreEqual(qrCode, receivedUserQrCode);
        }

        [Test]
        public void GoToAuthorizationTypeSelectIfUserAuthorizationPassedTest()
        {
            var testUser = new User();
            User receivedUser = null;

            CoreFactory.
                GetAuthorizationService().
                AuthorizeUser(string.Empty).
                Returns(testUser);

            CoreFactory.
                GetCoreNavigationService().
                GoToAuthorizationTypeSelect(Arg.Do<User>(n => receivedUser = n));


            var viewModel = new QrCodeGetterViewModel(CoreFactory);

            viewModel.GetQrCodeCommand.Execute(string.Empty);


            Assert.AreEqual(testUser, receivedUser);
        }

        [Test]
        public void GoToErrorScreenIfUserAuthorizationFailed()
        {
            var errorMessage = "Auth error";
            var receivedErrorMessage = string.Empty;

            CoreFactory.GetAuthorizationService()
                .AuthorizeUser(string.Empty)
                .Throws(new AuthorizationException(errorMessage));

            CoreFactory.
                GetCoreNavigationService().
                GoToErrorScreen(Arg.Do<string>(n => receivedErrorMessage = n), Arg.Any<Action>());

            var viewModel = new QrCodeGetterViewModel(CoreFactory);
            viewModel.GetQrCodeCommand.Execute(string.Empty);

            Assert.AreEqual(errorMessage, receivedErrorMessage);
        }
    }
}
