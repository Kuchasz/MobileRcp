using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    //Review: This class should go to Prabez.MobileRcp.Domain.Models or Prabez.MobileRcp.Domain.User.Models
    public class UserWorktime
    {
        //Review: User is not a part of UserWorktime, User can exist without UserWorktime
        //Get rid of that identity, User should have IEnumerable<UserWorktime>
        //Creating references from Child to Parent can then cause very not effective DBMS queries by ORM framework. Do not let child reference its parent.
        public int UserId { get; set; }
        public DateTime NormalIn { get; set; }
        public DateTime NormalOut { get; set; }
        public IEnumerable<DateTime> AdditionalEntrances { get; set; }
    }
}
