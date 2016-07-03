using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class LeaveCardToDisplay
    {
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DaysLeft { get; set; }
        public string IsAccepted { get; set; }
    }
}
