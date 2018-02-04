using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsParty.Models;
using WindowsParty.Services;

namespace WindowsParty.ViewModel
{
    public class ServersViewModel : ViewModelBase
    {

        private readonly ITesonetApiService _tesoService;
        private readonly IPagingService _pgService;
        private List<ServerModel> _servers;

        public List<ServerModel> Servers
        {
            get { return _servers; }
            set
            {
                _servers = value;
                RaisePropertyChanged(() => Servers);
            }
        }

        public ServersViewModel(ITesonetApiService tesoService, IPagingService winService)
        {
            _tesoService = tesoService;
            _pgService = winService;

            Init();
        }

        public async void Init()
        {
            Servers = await _tesoService.GetServers();
        }


        public ICommand LogoutClick => new RelayCommand(Logout);

        private void Logout()
        {
            _tesoService.Logout();
            _pgService.ShowLogin();
        }
    }
}
