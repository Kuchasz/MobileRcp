using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Definitions.Factories
{
    public interface IConvertersFactory
    {
        IValueConverter<IEnumerable<UserWorktime>, IEnumerable<UserWorktimeToDisplay>> GetWorktimeToDisplayConverter();
    }
}
