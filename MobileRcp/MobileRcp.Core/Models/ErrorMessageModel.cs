using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class ErrorMessageModel
    {
        public string ErrorMessage { get; set; }
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
