using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WindowsParty.Models;

namespace WindowsParty.Services.Impl
{
    public class TesonetApiService : ITesonetApiService
    {
        private readonly ILogService _log;
        public const string loginURL = "http://playground.tesonet.lt/v1/tokens";
        public const string serversURL = "http://playground.tesonet.lt/v1/servers";
        public string Token { get; set; }
        public bool LoggedIn => !string.IsNullOrEmpty(Token);

        public TesonetApiService(ILogService log)
        {
            _log = log;
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            using (var httpc = new HttpClient())
            {
                try
                {
                    var cont = new StringContent(JsonConvert.SerializeObject(new { username = loginModel.UserName, password = loginModel.Password }));
                    cont.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    _log.LogInfo($"Posting a login request to {loginURL} username: {loginModel.UserName}");
                    var rm = await httpc.PostAsync(loginURL, cont);
                    var rs = await rm.Content.ReadAsStringAsync();
                    var jo = JObject.Parse(rs);
                    var token = jo["token"]?.ToString();
                    _log.LogInfo($"Got token from WS: {token}");
                    Token = token;
                    return token != null;
                }
                catch(HttpRequestException e) {
                    _log.LogError($"Error while getting login response: {e}\r\n");
                    return false;
                }
                catch (JsonReaderException e)
                {
                    _log.LogError($"Error while reading JSON from response: {e}\r\n");
                    return false;
                }
                catch(Exception e)
                {
                    _log.LogError($"Error trying to log in: {e}\r\n");
                    return false;
                }
            }
        }

        public async Task<List<ServerModel>> GetServers()
        {
            if (!LoggedIn)
            {
                _log.LogError("Error while trying to get servers: User is not logged in. Token is null.");
                return null;
            }

            var wc = new WebClient();
            wc.Headers[HttpRequestHeader.Authorization] = $"Bearer {Token}";
            _log.LogInfo($"Downloading server data from {serversURL}");
            var servers = await wc.DownloadStringTaskAsync(new Uri(serversURL));
            var jo = JArray.Parse(servers);
            _log.LogInfo($"Successfully retrieved {jo.Count} servers.");
            return jo.Select(x => new ServerModel()
            {
                Name = x["name"].ToString(),
                Distance = int.Parse(x["distance"].ToString())
            }).ToList();
        }

        public void Logout()
        {
            _log.LogInfo("User has logged out.");
            Token = null;
        }
    }
}
