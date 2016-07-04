using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using MobileRcp.Core.ViewModels;
using MobileRcp.Droid.BaseTypes;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace MobileRcp.Droid.Activities.WorktimeStats
{
    [Activity(Label = "WorktimeStatsActivity")]
    public class WorktimeStatsActivity : DroidFragmentActivity
    {
        private ViewPager _viewPager;        
        public WorktimeStatsViewModel ViewModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WorktimeStats);

            ViewModel = Factory.GetWorktimeStatsViewModel();

            _viewPager = FindViewById<ViewPager>(Resource.Id.worktimePager);
            _viewPager.Adapter = new WorktimeStatsMonthFragmentAdapter(SupportFragmentManager, ViewModel);

            FindViewById<Button>(Resource.Id.worktimeStatsBackButton).SetCommand(ViewModel.GoBackCommand);       
            FindViewById<Button>(Resource.Id.worktimeStatsEndAuth).SetCommand(ViewModel.EndAuthorizationCommand);
        }
    }
}