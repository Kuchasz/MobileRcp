using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Definitions.Services
{
    public interface IUserStatsService
    {
        IEnumerable<UserWorktime> GetUserWorktimes(int userId, DateTime startDate, DateTime endDate);
        TimeSpan GetUserTotalWorktime(int userId, DateTime startDate, DateTime endDate);
        TimeSpan GetUserExpectedTotalWorktime(int userId, DateTime startDate, DateTime endData);
    }
}
