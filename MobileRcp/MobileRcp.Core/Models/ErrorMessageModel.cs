﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    //Review: It's not domain object, its application related. Move that to Prabez.MobileRcp.Application.Common.Models
    public class ErrorMessageModel
    {
        public string ErrorMessage { get; set; }
        //Review: Get rid of that action, it is better to extend NavigatorService with such ability:
        //navigationService.Navigate(errPage, pageToNavigateAfterError)
        public Action PostNavigationAction { get; set; }

        public ErrorMessageModel()
        {
            
        }

        public ErrorMessageModel(string errorMessage, Action postNavigationAction)
        {
            ErrorMessage = errorMessage;
            PostNavigationAction = postNavigationAction;
        }
    }
}
