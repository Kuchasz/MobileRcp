using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    //Review: I don't know domain requirements but i think this class name is not enough obvious
    //User should have reference to collection of LeaveCards
    public class LeaveCard
    {
        public LeaveType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAccepted { get; set; }
    }
}
