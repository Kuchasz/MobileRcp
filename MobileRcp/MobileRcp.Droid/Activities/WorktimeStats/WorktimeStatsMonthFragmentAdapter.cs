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
        private readonly IViewModelsFactory _factory;

        public WorktimeStatsMonthFragmentAdapter(IntPtr javaReference, JniHandleOwnership transfer) 
            : base(javaReference, transfer) {}

        public WorktimeStatsMonthFragmentAdapter(FragmentManager fm, IViewModelsFactory factory) : base(fm)
        {
            _factory = factory;
        }

        public override int Count => 3;

        public override Fragment GetItem(int position)
        {
            var viewModel = _factory.GetWorktimeStatsViewModel();

            viewModel.Date = DateTime.Now.AddMonths(-position);

            return new WorktimeStatsMonthFragment(viewModel);
        }
    }
}