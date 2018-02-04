using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsParty.Models;

namespace WindowsParty.Services
{
    public interface ITesonetApiService
    {
        Task<bool> Login(LoginModel loginModel);
        void Logout();
        Task<List<ServerModel>> GetServers();
    }
}
