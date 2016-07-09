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
    //Review: I would move that class to Prabez.Mvvm.Activites and won't use Droid word. ActivityBase class seem not to be android-related
    //Or if it is android-related keep this class name and place that in Prabez.Mvvm.Activities.Android namespace and derivate from Activity<T>
    //I would create public abstract class Activity<T> : ActivityBase where T: GalaSoft.MvvmLight.ViewModelBase with ViewModel property of type T
    //private readonly int View field in constructor
    //Prabez.Mvvm.Activities.Android -> AndroidActivity
    public abstract class DroidActivity : ActivityBase
    {
        public IViewModelsFactory Factory => App.GetViewModelsFactory(Intent);
    }
}