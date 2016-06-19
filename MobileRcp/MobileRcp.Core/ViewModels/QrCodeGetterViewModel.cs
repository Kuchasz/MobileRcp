using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Exceptions;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class QrCodeGetterViewModel : ViewModelBase
    {
        private readonly ICoreFactory _coreFactory;

        public RelayCommand<string> GetQrCodeCommand { get; private set; }

        public QrCodeGetterViewModel(ICoreFactory coreFactory)
        {
            _coreFactory = coreFactory;

            GetQrCodeCommand = new RelayCommand<string>(AuthorizeUserAction);
        }

        private void AuthorizeUserAction(string qrCode)
        {
            try
            {
                var user = _coreFactory.
                    GetAuthorizationService().
                    AuthorizeUser(qrCode);

                _coreFactory.
                    GetCoreNavigationService().
                    GoToAuthorizationTypeSelect(user);
            }
            catch (AuthorizationException exception)
            {
                _coreFactory.
                    GetCoreNavigationService().
                    GoToErrorScreen(new ErrorMessageModel(exception.Message, () => _coreFactory.GetCoreNavigationService().GoToQrCodeGetter()));
            }
            
        }
    }
}
