﻿using System;
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
                    Username = "Władek",
                    ImageUrl = "http://i1.kwejk.pl/k/users/thumbs/0643e1d087e8be7b04f2472564155e95.jpg",
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
