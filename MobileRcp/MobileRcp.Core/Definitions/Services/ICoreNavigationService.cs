using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.Definitions.Services
{
    public interface ICoreNavigationService
    {
        void GoToQrCodeGetter();
        void GoToErrorScreen(ErrorMessageModel errorMessage);
        void GoToAuthorizationTypeSelect(User user);
        TParameter GetNavigationParameter<TParameter>();
    }
}
