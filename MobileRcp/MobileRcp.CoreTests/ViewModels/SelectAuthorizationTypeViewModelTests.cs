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
    public class SelectAuthorizationTypeViewModelTests
    {
        public ICoreFactory CoreFactory { get; set; }

        public SelectAuthorizationTypeViewModelTests()
        {
            CoreFactory = Substitute.For<ICoreFactory>();
        }

        [Test]
        public void GetUserAuthorizationPropertiesTest()
        {
            var user = new User() { Id = 123, Username = "abc", ImageUrl = "img"};

            CoreFactory.GetCoreNavigationService().GetNavigationParameter<User>().Returns(user);

            var viewModel = new SelectAuthorizationTypeViewModel(CoreFactory);

            Assert.AreEqual(user.Username, viewModel.Username);
            Assert.AreEqual(user.ImageUrl, viewModel.ImageUrl);
            Assert.AreEqual(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), viewModel.EntryTime);
        }

        [Test]
        public void CancelComandInvokesNavigationServiceTest()
        {            
            CoreFactory.GetCoreNavigationService().GetNavigationParameter<User>().Returns(new User());

            var viewModel = new SelectAuthorizationTypeViewModel(CoreFactory);

            viewModel.CancelCommand.Execute(null);

            CoreFactory.GetCoreNavigationService().Received().GoToQrCodeGetter();
        }

        [Test]
        public void PassValidNormalInEntryTest()
        {
            PassValidEntryTypeAndUserIdentTest(EntryType.NormalIn, n => n.SetEntryAsNormalInCommand.Execute(null));
        }

        [Test]
        public void PassValidNormalOutEntryTest()
        {
            PassValidEntryTypeAndUserIdentTest(EntryType.NormalOut, n => n.SetEntryAsNormalOutCommand.Execute(null));
        }

        [Test]
        public void PassValidBusinessInEntryTest()
        {
            PassValidEntryTypeAndUserIdentTest(EntryType.BusinessIn, n => n.SetEntryAsBusinessInCommand.Execute(null));
        }

        [Test]
        public void PassValidBusinessOutEntryTest()
        {
            PassValidEntryTypeAndUserIdentTest(EntryType.BusinessOut, n => n.SetEntryAsBusinessOutCommand.Execute(null));
        }


        private void PassValidEntryTypeAndUserIdentTest(EntryType expectedEntry, Action<SelectAuthorizationTypeViewModel> viewModelSetEntryCommandExecute)
        {
            var user = new User() { Id = 123, Username = "abc" };
            CoreFactory.GetCoreNavigationService().GetNavigationParameter<User>().Returns(user);
            var receivedUserIdent = 0;
            EntryType receivedEntry = EntryType.BusinessIn;

            CoreFactory.GetAuthorizationService().SetUserEntrance(Arg.Do<int>(n => receivedUserIdent = n), Arg.Do<EntryType>(n => receivedEntry = n));

            var viewModel = new SelectAuthorizationTypeViewModel(CoreFactory);

            viewModelSetEntryCommandExecute.Invoke(viewModel);

            Assert.AreEqual(user.Id, receivedUserIdent);
            Assert.AreEqual(expectedEntry, receivedEntry);
        }

    }
}
