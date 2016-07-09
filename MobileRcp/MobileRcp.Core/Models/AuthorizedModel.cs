using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    //Review: I would move that to Prabez.Security.Authorization.Models
    public class AuthorizedModel
    {
        public EntryType EntryType { get; set; }
        public DateTime Date { get; set; }
        public UserAuthorizationData AuthorizationData { get; set; }
    }
}
