using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Definitions.Services
{
    public interface IAuthorizationService
    {
        User AuthorizeUser(string userQrToken);
        void SetUserEntrance(UserAuthorizationData authorizationData, EntryType entryType);
    }
}
