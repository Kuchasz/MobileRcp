using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileRcp.Core.Models;

//Review: Move that to Prabez.MobileRcp.Application.Services, get rid of Core word
//I'm not sure if such catch-them-all navigation interface is a good idea.
namespace MobileRcp.Core.Definitions.Services
{
    //Review: Do not use domain-objects in application-level code. Use [DomainObject]Dto classes
    public interface ICoreNavigationService
    {
        void GoToQrCodeGetter();
        void GoToErrorScreen(ErrorMessageModel errorMessage);
        void GoToAuthorizationTypeSelect(User user);
        void GoToAuthorizationCompleted(AuthorizedModel authorizedModel);
        void GoToWorktimeStats(AuthorizedModel authorizedModel);
        void GoToLeaveStats(AuthorizedModel authorizedModel);

        TParameter GetNavigationParameter<TParameter>();
    }
}
