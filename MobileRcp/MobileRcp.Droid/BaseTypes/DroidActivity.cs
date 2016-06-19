using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using MobileRcp.Core.Definitions.Factories;

namespace MobileRcp.Droid.BaseTypes
{
    public class DroidActivity : ActivityBase
    {
        public IViewModelsFactory Factory => App.GetViewModelsFactory(Intent);
    }
}