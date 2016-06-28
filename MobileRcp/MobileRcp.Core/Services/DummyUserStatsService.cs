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
            startDate = startDate.AddDays(-(startDate.Day - 1));

            for (int i = 0; i < 30; i++)
            {
                yield return new UserWorktime()
                {
                    UserId = 1,
                    NormalIn = startDate.AddDays(i),
                    NormalOut = startDate.AddDays(i).AddHours(8)
                };
            }
        }
    }
}
