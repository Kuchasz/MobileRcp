using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    //Review: Try to avoid Data word in domain objects
    public class UserAuthorizationData
    {
        //Review: Avoid using shorten names for exposed members
        public int UserIdent { get; set; }
        public string UserAuthorizationToken { get; set; }
    }
}
