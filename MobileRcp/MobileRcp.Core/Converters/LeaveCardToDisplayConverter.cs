using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Converters
{
    public class LeaveCardToDisplayConverter : IValueConverter<IEnumerable<LeaveCard>, IEnumerable<LeaveCardToDisplay>>
    {
        public IEnumerable<LeaveCardToDisplay> Convert(IEnumerable<LeaveCard> model)
        {
            return model.Select(n => new LeaveCardToDisplay()
            {
                Type = TypeFormat(n.Type),
                IsAccepted = IsAcceptedFormat(n.IsAccepted),
                DaysLeft = DaysLeftFormat(n.StartDate),
                StartDate = DateFormat(n.StartDate),
                EndDate = DateFormat(n.EndDate)
            });
        }

        private string TypeFormat(LeaveType type)
        {
            switch (type)
            {
                case LeaveType.Normal:
                    return "Urlop";
                default:
                    return "-";
            }
        }

        private string IsAcceptedFormat(bool isAccepted)
        {
            return isAccepted ? "Tak" : "Nie";
        }

        private string DaysLeftFormat(DateTime startDate)
        {
            var timeLeft = startDate - DateTime.Now;

            return timeLeft.TotalDays.ToString("####");
        }

        private string DateFormat(DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}
