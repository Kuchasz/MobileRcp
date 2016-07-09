using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class UserAuthorizationData
    {
        //Review: Avoid using shorten names for public members
        public int UserIdent { get; set; }
        public string UserAuthorizationToken { get; set; }
    }
}
