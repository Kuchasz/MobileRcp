using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    //Review: I would place this class in Prabez.MobileRcp.Application.Common.ViewModels
    public class ErrorScreenViewModel : ViewModelWithParameter<ErrorMessageModel>
    {
        private readonly ICoreFactory _coreFactory;

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { Set(() => ErrorMessage, ref _errorMessage, value); }
        }

        public RelayCommand ExecutePostActionCommand { get; private set; }
        
        public ErrorScreenViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            _coreFactory = coreFactory;

            ExecutePostActionCommand = new RelayCommand(ViewModelParameter.PostNavigationAction);
            ErrorMessage = ViewModelParameter.ErrorMessage;
        }
    }
}
