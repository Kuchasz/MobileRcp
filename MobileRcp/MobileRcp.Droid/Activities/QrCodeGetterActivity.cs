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
using ZXing.Mobile;

namespace MobileRcp.Droid.Activities
{
    [Activity(Label = "QrCodeGetterActivity")]
    public class QrCodeGetterActivity : Activity
    {
        private QrCodeGetterViewModel _viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _viewModel = App.GetViewModelsFactory(Intent).GetQrCodeGetterViewModel();

            MobileBarcodeScanner.Initialize(Application);

            GetCode();
        }

        private async void GetCode()
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                _viewModel.GetQrCodeCommand.Execute(result.Text);                
            }
        }
    }
}