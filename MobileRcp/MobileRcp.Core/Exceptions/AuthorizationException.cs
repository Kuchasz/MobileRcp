using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
        {
            
        }

        public AuthorizationException(string errorMessage) : base(errorMessage)
        {
            
        }
    }
}
