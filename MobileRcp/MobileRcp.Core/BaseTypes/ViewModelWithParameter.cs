using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MobileRcp.Core.Definitions.Factories;

namespace MobileRcp.Core.BaseTypes
{
    //Review: This class could be placed in Prabez.Mvvm.BaseTypes or Prabez.Mvvm.Models or Prabez.Mvvm (third one i think will be the best)
    public abstract class ViewModelWithParameter<TParam> : ViewModelBase
    {
        protected TParam ViewModelParameter { get; private set; }

        protected ViewModelWithParameter(ICoreFactory coreFactory)
        {
            ViewModelParameter = coreFactory.
                GetCoreNavigationService().
                GetNavigationParameter<TParam>();
        }
    }
}
