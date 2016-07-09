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
using GalaSoft.MvvmLight.Helpers;
using MobileRcp.Core.ViewModels;
using MobileRcp.Droid.BaseTypes;

namespace MobileRcp.Droid.Activities
{
    [Activity(Label = "ErrorScreenActivity")]
    public class ErrorScreenActivity : DroidActivity
    {
        public ErrorScreenViewModel ViewModel { get; set; }
        public TextView ErrorTextView { get; set; }

        //Review: All this logic could be placed in Activity<T> or DroidActivity<T> class
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ErrorScreen);

            ViewModel = Factory.GetErrorScreenViewModel();

            SetBinding();
        }

        //this could be protected virtual method in Activity<T> and override in each activity (there could be activites that won't have any bindings)
        private void SetBinding()
        {
            FindViewById<Button>(Resource.Id.errorOk).SetCommand("Click", ViewModel.ExecutePostActionCommand);
            ErrorTextView = FindViewById<TextView>(Resource.Id.errorText);
            this.SetBinding(() => ViewModel.ErrorMessage, () => ErrorTextView.Text, BindingMode.OneWay);            
        }
    }
}