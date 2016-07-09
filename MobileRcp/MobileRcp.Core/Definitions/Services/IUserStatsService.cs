using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Definitions.Services
{
    //Review: This is domain-specific service, should be placed in Prabez.MobileRcp.Domain.Services namespace
    //Or if your domain is big enough it would be worth to split it into functional areas, eg: Prabez.MobileRcp.Domain.User.Services
    //Do not use that class in ViewModels i suppose that your domain logic it is goin to be hosted on ASP.NET webservice so services with domain logic should not be called from viewmodels
    //You can create wrappers that begind-the-scene will call remote APIs
    public interface IUserStatsService
    {
        IEnumerable<UserWorktime> GetUserWorktimes(int userId, DateTime startDate, DateTime endDate);
        TimeSpan GetUserTotalWorktime(int userId, DateTime startDate, DateTime endDate);
        TimeSpan GetUserExpectedTotalWorktime(int userId, DateTime startDate, DateTime endData);
        int GetUserLeavesLeft(int userId);
        IEnumerable<LeaveCard> GetUserLeavesCards(int userId);
    }
}
