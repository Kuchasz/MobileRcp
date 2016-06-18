using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileRcp.Core.BaseTypes;
using MobileRcp.Core.Definitions.Factories;
using MobileRcp.Core.Models;

namespace MobileRcp.Core.ViewModels
{
    public class SelectAuthorizationTypeViewModel : ViewModelWithParameter<User>
    {
        private readonly ICoreFactory _coreFactory;

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
            _coreFactory.GetAuthorizationService().SetUserEntrance(ViewModelParameter.Id, entryType);
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
            Username = ViewModelParameter.Username;
            EntryTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            ImageUrl = ViewModelParameter.ImageUrl;
        }
    }
}
