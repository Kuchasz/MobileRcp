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

namespace MobileRcp.Droid.Activities
{
    public class LeaveStatsCardsAdapter : BaseAdapter<LeaveCardToDisplay>
    {
        private readonly Activity _activity;
        private readonly LeaveCardToDisplay[] _cards;

        public LeaveStatsCardsAdapter(Activity activity, IEnumerable<LeaveCardToDisplay> cards)
        {
            _activity = activity;
            _cards = cards.ToArray();
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.LeaveStatsCard, parent, false);

            var card = this[position];

            view.FindViewById<TextView>(Resource.Id.cardType).Text = card.Type;
            view.FindViewById<TextView>(Resource.Id.cardDate).Text = card.StartDate + " - " + card.EndDate;
            view.FindViewById<TextView>(Resource.Id.cardDays).Text = card.DaysLeft;
            view.FindViewById<TextView>(Resource.Id.cardAccepted).Text = card.IsAccepted;


            return view;
        }

        public override int Count => _cards.Length;

        public override LeaveCardToDisplay this[int position] => _cards[position];
    }
}