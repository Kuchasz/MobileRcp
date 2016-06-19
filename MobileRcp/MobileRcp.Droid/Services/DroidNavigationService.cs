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
using GalaSoft.MvvmLight.Views;
using MobileRcp.Core.Definitions.Services;
using MobileRcp.Core.Models;

namespace MobileRcp.Droid.Services
{
    public class DroidNavigationService : ICoreNavigationService
    {
        private readonly NavigationService _navigationService;
        private Intent _intent;

        public DroidNavigationService()
        {
            _navigationService = new NavigationService();
        }


        public void GoToQrCodeGetter()
        {
            throw new NotImplementedException();
        }

        public void GoToErrorScreen(ErrorMessageModel errorMessage)
        {
            throw new NotImplementedException();
        }

        public void GoToAuthorizationTypeSelect(User user)
        {
            throw new NotImplementedException();
        }

        public void GoToAuthorizationCompleted(AuthorizedModel authorizedModel)
        {
            throw new NotImplementedException();
        }

        public void GoToWorktimeStats(AuthorizedModel authorizedModel)
        {
            throw new NotImplementedException();
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