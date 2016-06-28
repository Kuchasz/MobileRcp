using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class UserWorktimeToDisplay
    {
        public string Day { get; set; }
        public string NormalInTime { get; set; }
        public string NormalOutTime { get; set; }
        public string IsAdditionalsLeaves { get; set; }
        public string Worktime { get; set; }
    }
}
