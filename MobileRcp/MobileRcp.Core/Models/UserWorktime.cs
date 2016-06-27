using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class UserWorktime
    {
        public int UserId { get; set; }
        public DateTime NormalIn { get; set; }
        public DateTime NormalOut { get; set; }
        public IEnumerable<DateTime> AdditionalEntrances { get; set; }
    }
}
