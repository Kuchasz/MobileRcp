using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Converters;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Factories
{
    public class ConvertersFactory : IConvertersFactory
    {
        public IValueConverter<IEnumerable<UserWorktime>, IEnumerable<UserWorktimeToDisplay>> GetWorktimeToDisplayConverter()
        {
            return new UserWorktimeToDisplayConverter();
        }

        public IValueConverter<IEnumerable<LeaveCard>, IEnumerable<LeaveCardToDisplay>> GetLeaveCardConverter()
        {
            return new LeaveCardToDisplayConverter();
        }
    }
}
