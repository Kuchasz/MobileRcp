using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Models;

//Review: Namespaces should start with author/company name, eg:
//(Prabez|RPles|Ples).MobileRcp...
//I would move that member into Prabez.Security.Authorization.Services
namespace MobileRcp.Core.Definitions.Services
{
    public interface IAuthorizationService
    {
        User AuthorizeUser(string userQrToken);
        void SetUserEntrance(UserAuthorizationData authorizationData, EntryType entryType);
    }
}
