using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class User
    {
        public UserAuthorizationData AuthorizationData { get; set; }        
        public string Username { get; set; }
        public string ImageUrl { get; set; }        
    }
}
