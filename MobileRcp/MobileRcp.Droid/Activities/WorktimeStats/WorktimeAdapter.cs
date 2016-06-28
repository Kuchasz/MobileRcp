using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using MobileRcp.Core.Models;

namespace MobileRcp.Droid.Activities.WorktimeStats
{
    public class WorktimeAdapter : BaseAdapter<UserWorktimeToDisplay>
    {
        private readonly Activity _activity;
        private readonly UserWorktimeToDisplay[] _worktimes;

        public WorktimeAdapter(Activity activity, IEnumerable<UserWorktimeToDisplay> worktimes)
        {
            _activity = activity;
            _worktimes = worktimes.ToArray();
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.WorktimeStatsItem, parent, false);

            var textDay = view.FindViewById<TextView>(Resource.Id.wokrtimeItemDay);
            var textIn = view.FindViewById<TextView>(Resource.Id.wokrtimeItemIn);
            var textAdditionals = view.FindViewById<TextView>(Resource.Id.wokrtimeItemAdditionals);
            var textOut = view.FindViewById<TextView>(Resource.Id.wokrtimeItemOut);
            var textTime = view.FindViewById<TextView>(Resource.Id.wokrtimeItemTime);

            var worktime = this[position];

            textDay.Text = worktime.Day;
            textIn.Text = worktime.NormalInTime;
            textAdditionals.Text = worktime.IsAdditionalsLeaves;
            textOut.Text = worktime.NormalOutTime;
            textTime.Text = worktime.Worktime;

            return view;
        }

        public override int Count => _worktimes.Length;

        public override UserWorktimeToDisplay this[int position] => _worktimes[position];
    }
}