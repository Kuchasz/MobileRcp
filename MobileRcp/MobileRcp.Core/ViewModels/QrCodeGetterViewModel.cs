using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.Definitions.Factories;

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
            catch (Exception e)
            {
                _coreFactory.
                    GetCoreNavigationService().
                    GoToErrorScreen(e.Message, () => _coreFactory.GetCoreNavigationService().GoToQrCodeGetter());
            }
            
        }
    }
}
