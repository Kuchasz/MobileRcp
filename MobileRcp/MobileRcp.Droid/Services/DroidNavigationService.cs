using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Accounts;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Models;
using MobileRcp.Droid.Activities;
using MobileRcp.Droid.Activities.WorktimeStats;

namespace MobileRcp.Droid.Services
{
    public class DroidNavigationService : ICoreNavigationService
    {
        private readonly NavigationService _navigationService;
        private Intent _intent;

        private const string AuthorizarionTypeSelectKey = "authorizarionTypeSelectKey";
        private const string ErrorScreenKey = "errorScreenKey";
        private const string QrCodeGetterKey = "qrCodeGetterKey";
        private const string AuthorizationCompletedKey = "AuthorizationCompletedKey";
        private const string WorktimeStatsKey = "WorktimeStatsKey";

        public DroidNavigationService()
        {
            _navigationService = new NavigationService();

            ConfigureNavigationService();
        }

        private void ConfigureNavigationService()
        {
            _navigationService.Configure(AuthorizarionTypeSelectKey, typeof(SelectAuthorizationTypeActivity));
            _navigationService.Configure(ErrorScreenKey, typeof(ErrorScreenActivity));
            _navigationService.Configure(QrCodeGetterKey, typeof(QrCodeGetterActivity));
            _navigationService.Configure(AuthorizationCompletedKey, typeof(AuthorizationCompletedActivity));
            _navigationService.Configure(WorktimeStatsKey, typeof(WorktimeStatsActivity));
        }


        public void GoToQrCodeGetter()
        {
            _navigationService.NavigateTo(QrCodeGetterKey);
        }

        public void GoToErrorScreen(ErrorMessageModel errorMessage)
        {
            _navigationService.NavigateTo(ErrorScreenKey, errorMessage);
        }

        public void GoToAuthorizationTypeSelect(User user)
        {
            _navigationService.NavigateTo(AuthorizarionTypeSelectKey, user);
        }

        public void GoToAuthorizationCompleted(AuthorizedModel authorizedModel)
        {
            _navigationService.NavigateTo(AuthorizationCompletedKey, authorizedModel);
        }

        public void GoToWorktimeStats(AuthorizedModel authorizedModel)
        {
            _navigationService.NavigateTo(WorktimeStatsKey, authorizedModel);
        }

        public void GoToLeaveStats(AuthorizedModel authorizedModel)
        {
            throw new NotImplementedException();
        }

        public TParameter GetNavigationParameter<TParameter>()
        {
            return _navigationService.GetAndRemoveParameter<TParameter>(_intent);
        }

        public void SetCurrentIntent(Intent intent)
        {
            _intent = intent;
        }
    }
}