using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using MobileRcp.Core.ViewModels;
using MobileRcp.Droid.BaseTypes;

namespace MobileRcp.Droid.Activities
{
    [Activity(Label = "SelectAuthorizationTypeActivity")]
    public class SelectAuthorizationTypeActivity : DroidActivity
    {        
        public SelectAuthorizationTypeViewModel ViewModel { get; set; }
        public TextView UsernameTextView { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SelectAuthorizationType);

            ViewModel = Factory.GeSelectAuthorizationTypeViewModel();

            SetBindings();
        }

        private void SetBindings()
        {
            FindViewById<Button>(Resource.Id.authTypeNormalIn).SetCommand("Click", ViewModel.SetEntryAsNormalInCommand);
            FindViewById<Button>(Resource.Id.authTypeNormalOut).SetCommand("Click", ViewModel.SetEntryAsNormalOutCommand);
            FindViewById<Button>(Resource.Id.authTypeWorkIn).SetCommand("Click", ViewModel.SetEntryAsBusinessInCommand);
            FindViewById<Button>(Resource.Id.authTypeWorkOut).SetCommand("Click", ViewModel.SetEntryAsBusinessOutCommand);
            FindViewById<Button>(Resource.Id.authTypeCancel).SetCommand("Click", ViewModel.CancelCommand);

            UsernameTextView = FindViewById<TextView>(Resource.Id.authTypeUsername);
            this.SetBinding(() => ViewModel.Username, () => UsernameTextView.Text);

            FindViewById<ImageView>(Resource.Id.authTypeImage).SetImageBitmap(GetImageBitmapFromUrl(ViewModel.ImageUrl));
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            if (url != "null")
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

            return imageBitmap;
        }
    }
}