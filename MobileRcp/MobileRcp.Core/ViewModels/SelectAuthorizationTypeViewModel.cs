using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Exceptions;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    //Review: I would place this class in Prabez.MobileRcp.Application.Authorization.ViewModels
    public class SelectAuthorizationTypeViewModel : ViewModelWithParameter<User>
    {
        private readonly ICoreFactory _coreFactory;
        private DateTime _userEntryTime;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { Set(() => Username, ref _username, value); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl;}
            set { Set(() => ImageUrl, ref _imageUrl, value); }
        }

        private string _entryTime;
        public string EntryTime
        {
            get { return _entryTime; }
            set { Set(() => EntryTime, ref _entryTime, value); }
        }

        public RelayCommand SetEntryAsNormalInCommand { get; private set; }
        public RelayCommand SetEntryAsNormalOutCommand { get; private set; }
        public RelayCommand SetEntryAsBusinessInCommand { get; private set; }
        public RelayCommand SetEntryAsBusinessOutCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public SelectAuthorizationTypeViewModel(ICoreFactory coreFactory) : base(coreFactory)
        {
            _coreFactory = coreFactory;

            SetCommands();
            SetParams();
        }

        private void SetUserEntryType(EntryType entryType)
        {
            try
            {
                _coreFactory.
                    GetAuthorizationService().
                    SetUserEntrance(ViewModelParameter.AuthorizationData, entryType);

                _coreFactory.
                    GetCoreNavigationService().
                    GoToAuthorizationCompleted(PrepareAuthorizedModel(entryType));
            }
            catch (AuthorizationException exception)
            {                
                _coreFactory.
                    GetCoreNavigationService().
                    GoToErrorScreen(new ErrorMessageModel(exception.Message, _coreFactory.GetCoreNavigationService().GoToQrCodeGetter));
            }            
        }

        private AuthorizedModel PrepareAuthorizedModel(EntryType entryType)
        {
            return new AuthorizedModel()
            {
                EntryType = entryType,
                Date = _userEntryTime,
                AuthorizationData = ViewModelParameter.AuthorizationData
            };
        }

        private void CancelSelection()
        {
            _coreFactory.GetCoreNavigationService().GoToQrCodeGetter();
        }

        private void SetCommands()
        {
            SetEntryAsNormalInCommand = new RelayCommand(() => SetUserEntryType(EntryType.NormalIn));
            SetEntryAsNormalOutCommand = new RelayCommand(() => SetUserEntryType(EntryType.NormalOut));
            SetEntryAsBusinessInCommand = new RelayCommand(() => SetUserEntryType(EntryType.BusinessIn));
            SetEntryAsBusinessOutCommand = new RelayCommand(() => SetUserEntryType(EntryType.BusinessOut));
            CancelCommand = new RelayCommand(CancelSelection);
        }

        private void SetParams()
        {
            _userEntryTime = DateTime.Now;
            Username = ViewModelParameter.Username;
            EntryTime = _userEntryTime.ToString("dd-MM-yyyy HH:mm");
            ImageUrl = ViewModelParameter.ImageUrl;
        }
    }
}
