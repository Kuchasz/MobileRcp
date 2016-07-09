using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Converters
{
    //Review: Possibly gou gonna have much more converters like this, instead of create converter for each model class create one converter for each aggregate object, eg UserConverter in Prabez.MobileRcp.Application.Converters in place there metods: LeaveCardToDto, LeaveCardFromDto, UserWorktimeToDto, UserWorktimeFromDto
    //UserWorktime and LeaveCard seem to be child objects to User
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

        //Review: Do not hard-type strings like this. Create IResourceService with .Resolve(string key) method. Concrete ResourcesService should be initialized with Culture name and then pick proper resource file/files from assets.
        //Sample: 
        /*
         ../resources/pl-PL/User.json
         {
         ...
            LeaveTypeName_Normal: 'Urlop',
            LeaveTypeName_Foo: '.....',
         ...
         }
             */
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
