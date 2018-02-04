using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WindowsParty.Models;
using WindowsParty.Services;

namespace WindowsParty.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public string UserName { get; set; }
        public bool ShowingError { get; set; }
        private readonly ITesonetApiService _tesoService;
        private readonly IPagingService _pgService;
        private readonly ILogService _log;

        public LoginViewModel(ITesonetApiService tesoService, IPagingService pgService, ILogService log)
        {
            _tesoService = tesoService;
            _pgService = pgService;
            _log = log;
            _log.LogInfo("Application started");
        }

        public ICommand LoginClick => new RelayCommand<PasswordBox>(Login);

        public async void Login(PasswordBox passwordBox)
        {
            ShowingError = false;
            RaisePropertyChanged(() => ShowingError);
            _log.LogInfo($"User {UserName} attempting to login");
            var success = await _tesoService.Login(new LoginModel() { UserName = UserName, Password = passwordBox.Password });
            _log.LogInfo($"User {UserName} login attempt was {(success ? "" : "un")}successful");
            ShowingError = !success;
            RaisePropertyChanged(() => ShowingError);

            if (success)
                _pgService.ShowServers();
        }
    }
}
