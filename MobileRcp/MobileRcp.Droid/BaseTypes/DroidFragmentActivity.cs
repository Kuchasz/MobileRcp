using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MobileRcp.Core.Definitions.Factories;

namespace MobileRcp.Droid.BaseTypes
{
    public abstract class DroidFragmentActivity : FragmentActivity
    {
        public IViewModelsFactory Factory => App.GetViewModelsFactory(Intent);
    }
}