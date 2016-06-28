using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Definitions.Converters;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Converters
{
    public class UserWorktimeToDisplayConverter : IValueConverter<IEnumerable<UserWorktime>, IEnumerable<UserWorktimeToDisplay>>
    {
        public IEnumerable<UserWorktimeToDisplay> Convert(IEnumerable<UserWorktime> model)
        {
            return model.Select(item => new UserWorktimeToDisplay()
            {
                Day = GetDay(item),
                NormalInTime = GetNormalIn(item),
                NormalOutTime = GetNormalOut(item),
                IsAdditionalsLeaves = GetAdditionalLeaves(item),
                Worktime = GetWorktime(item)
            });
        }

        private string GetDay(UserWorktime item)
        {
            return item.NormalIn == DateTime.MinValue 
                ? "-" 
                : item.NormalIn.ToString("dd");
        }

        private string GetNormalIn(UserWorktime model)
        {
            return model.NormalIn == DateTime.MinValue 
                ? "-" 
                : model.NormalIn.ToString("HH:mm");
        }

        private string GetNormalOut(UserWorktime model)
        {
            return model.NormalOut == DateTime.MinValue
                ? "-"
                : model.NormalOut.ToString("HH:mm");
        }

        private string GetAdditionalLeaves(UserWorktime model)
        {
            return model.AdditionalEntrances != null && model.AdditionalEntrances.Any()
                ? "Tak"
                : "Nie";
        }

        private string GetWorktime(UserWorktime model)
        {
            if (model.NormalIn > DateTime.MinValue && model.NormalOut > model.NormalIn)
            {
                var worktime = model.NormalOut - model.NormalIn;

                return $"{worktime.Hours.ToString("00.##") }:{worktime.Minutes.ToString("00.##") }";
            }

            return "-";
        }
    }
}
