using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Services
{
    public class DummyUserStatsService : IUserStatsService
    {
        public IEnumerable<UserWorktime> GetUserWorktimes(int userId, DateTime startDate, DateTime endDate)
        {
            return new[]
            {
                new UserWorktime()
                {
                    UserId = 1,
                    NormalIn = startDate,
                    NormalOut = startDate.AddHours(8)
                },
                new UserWorktime()
                {
                    UserId = 1,
                    NormalIn = startDate.AddDays(1),
                    NormalOut = startDate.AddDays(1).AddHours(8)
                },
            };
        }
    }
}
