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
    public class ErrorScreenViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }

        public ErrorScreenViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();
        }

        [Test]
        public void ShowErrorMessageFromParameterTest()
        {
            var errorMessage = new ErrorMessageModel("testError", () => {});
            CoreFactory.GetCoreNavigationService().GetNavigationParameter<ErrorMessageModel>().Returns(errorMessage);

            var viewModel = new ErrorScreenViewModel(CoreFactory);

            Assert.AreEqual(viewModel.ErrorMessage, errorMessage.ErrorMessage);
        }

        [Test]
        public void ExecutePostActionCommandTest()
        {
            var isReceivedCall = false;
            var errorMessage = new ErrorMessageModel("testError", () => isReceivedCall = true);
            CoreFactory.GetCoreNavigationService().GetNavigationParameter<ErrorMessageModel>().Returns(errorMessage);

            var viewModel = new ErrorScreenViewModel(CoreFactory);

            viewModel.ExecutePostActionCommand.Execute(null);

            Assert.True(isReceivedCall);
        }
    }
}
