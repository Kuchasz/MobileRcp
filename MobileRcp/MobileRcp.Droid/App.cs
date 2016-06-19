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
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Factories;
using MobileRcp.Droid.Services;

namespace MobileRcp.Droid
{
    [Application]
    public class App : Application
    {
        private static DroidNavigationService _droidNavigationService;
        private static ICoreFactory _coreFactory;
        private static IViewModelsFactory _viewModelsFactory;

        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {

        }

        public override void OnCreate()
        {
            _droidNavigationService = new DroidNavigationService();
            _coreFactory = new CoreFactory(_droidNavigationService);
            _viewModelsFactory = new ViewModelsFactory(_coreFactory);

            base.OnCreate();
        }

        public static IViewModelsFactory GetViewModelsFactory(Intent currentIntent)
        {
            _droidNavigationService.SetCurrentIntent(currentIntent);

            return _viewModelsFactory;
        }
    }
}