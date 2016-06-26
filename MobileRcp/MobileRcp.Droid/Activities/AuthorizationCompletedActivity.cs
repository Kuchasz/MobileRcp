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
    [Activity(Label = "AuthorizationCompletedActivity")]
    public class AuthorizationCompletedActivity : DroidActivity
    {
        public AuthorizationCompletedViewModel ViewModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AuthorizationCompleted);

            ViewModel = Factory.GetAuthorizationCompletedViewModel();

            SetBinding();
        }

        

        private void SetBinding()
        {
            FindViewById<Button>(Resource.Id.completedWorktime).SetCommand("Click", ViewModel.ShowWorktimeCommand);
            FindViewById<Button>(Resource.Id.completedLeaves).SetCommand("Click", ViewModel.ShowLeaveStatsCommand);
            FindViewById<Button>(Resource.Id.completedEnd).SetCommand("Click", ViewModel.EndAuthorizationCommand);
        }
    }
}