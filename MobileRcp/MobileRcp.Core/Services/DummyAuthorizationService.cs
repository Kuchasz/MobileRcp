using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Exceptions;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Services
{
    public class DummyAuthorizationService : IAuthorizationService
    {
        public User AuthorizeUser(string userQrToken)
        {
            if (userQrToken == "69")
            {
                return new User()
                {
                    Username = "Rafał",
                    ImageUrl = "https://avatars0.githubusercontent.com/u/13023627?v=3&s=40",
                    AuthorizationData = new UserAuthorizationData()
                    {
                        UserIdent = 1,
                        UserAuthorizationToken = "testToken"
                    }
                };
            }

            throw new AuthorizationException("Nieprawidłowy kod QR pracownika.");
        }

        public void SetUserEntrance(UserAuthorizationData authorizationData, EntryType entryType)
        {
            if (authorizationData.UserIdent == 1 && authorizationData.UserAuthorizationToken == "testToken")
            {
                return;
            }

            throw new AuthorizationException("Niewłaściwy token użytkownika.");
        }
    }
}
