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
    [Activity(Label = "LeaveStatsActivity")]
    public class LeaveStatsActivity : DroidActivity
    {
        public ListView CardsList { get; set; }
        public LeaveStatsViewModel ViewModel { get; set; }
        public TextView DaysLeft { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LeaveStats);

            ViewModel = Factory.GetLeaveStatsViewModel();

            FindViewById<Button>(Resource.Id.leaveStatsGoBack).SetCommand(ViewModel.GoBackCommand);

            CardsList = FindViewById<ListView>(Resource.Id.leavesStatsCards);

            CardsList.Adapter = new LeaveStatsCardsAdapter(this, ViewModel.LeavesCards);

            DaysLeft = FindViewById<TextView>(Resource.Id.leavesStatsDaysLeft);

            this.SetBinding(() => ViewModel.LeavesLeft, () => DaysLeft.Text);
        }

        
    }
}