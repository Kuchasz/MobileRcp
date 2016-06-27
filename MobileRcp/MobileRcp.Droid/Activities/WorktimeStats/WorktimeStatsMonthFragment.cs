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
using MobileRcp.Core.Models;
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
            
            list.Adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, _viewModel.Worktimes.Select(n => n.NormalIn.ToString()).ToList());

            return view;
        }
    }
}