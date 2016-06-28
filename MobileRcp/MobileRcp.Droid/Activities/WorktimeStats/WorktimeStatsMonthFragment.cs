using System;
using System.Globalization;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using MobileRcp.Core.ViewModels;
using Fragment = Android.Support.V4.App.Fragment;
using ListFragment = Android.Support.V4.App.ListFragment;

namespace MobileRcp.Droid.Activities.WorktimeStats
{
    public class WorktimeStatsMonthFragment : Fragment
    {
        private readonly WorktimeStatsViewModel _viewModel;

        public WorktimeStatsMonthFragment(WorktimeStatsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.WorktimeStatsMonth, container, false);
            
            var list = view.FindViewById<ListView>(Resource.Id.worktimesList);
            view.FindViewById<TextView>(Resource.Id.worktimeMonth).Text = _viewModel.Date.ToString("MMMM", new CultureInfo("pl-PL"));
            view.FindViewById<TextView>(Resource.Id.worktimeTotal);

            list.Adapter = new WorktimeAdapter(Activity, _viewModel.Worktimes);            

            return view;
        }
    }
}