using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class LeaveStatsViewModel : ViewModelWithParameter<AuthorizedModel>
    {

        public LeaveStatsViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            
        }
    }
}
