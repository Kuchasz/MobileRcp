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
using MobileRcp.Core.ViewModels;
using MobileRcp.Droid.BaseTypes;
using ZXing.Mobile;

namespace MobileRcp.Droid.Activities
{
    [Activity(Label = "QrCodeGetterActivity", MainLauncher = true)]
    public class QrCodeGetterActivity : DroidActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MobileBarcodeScanner.Initialize(Application);

            GetCode();
        }

        private async void GetCode()
        {
            var scanner = new MobileBarcodeScanner();


            if (result != null)
            {
                Factory.GetQrCodeGetterViewModel().GetQrCodeCommand.Execute(result.Text);                
            }
        }
    }
}