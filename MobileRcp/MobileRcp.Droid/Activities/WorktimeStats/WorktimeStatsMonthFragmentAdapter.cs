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
using MobileRcp.Core.ViewModels;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace MobileRcp.Droid.Activities.WorktimeStats
{
    public class WorktimeStatsMonthFragmentAdapter : FragmentPagerAdapter
    {
        private readonly WorktimeStatsViewModel _viewModel;
        private readonly IViewModelsFactory _factory;

        public WorktimeStatsMonthFragmentAdapter(IntPtr javaReference, JniHandleOwnership transfer) 
            : base(javaReference, transfer) {}

        public WorktimeStatsMonthFragmentAdapter(FragmentManager fm, WorktimeStatsViewModel viewModel) : base(fm)
        {
            _viewModel = viewModel;
        }

        public override int Count => _viewModel.WorktimeMonths.Count;

        public override Fragment GetItem(int position)
        {
            return new WorktimeStatsMonthFragment(_viewModel.WorktimeMonths[position]);
        }
    }
}